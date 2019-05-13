using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelRecord.Model
{
    public class Post : INotifyPropertyChanged
    {

        private string id;
        private string venueName;
        private string categoryId;
        private string categoryName;
        private string address;
        private double latitude;
        private double longitude;
        private int distance;
        private string userId;

        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertychanged("Id");
            }
        }

        private string experience;

        public string Experience
        {
            get { return experience; }
            set
            {
                experience = value;
                OnPropertychanged("Experience");
            }
        }

        public string VenueName
        {
            get { return venueName; }
            set
            {
                venueName = value;
                OnPropertychanged("VenueName");
            }
        }

        public string CategoryId
        {
            get => categoryId;
            set
            {
                categoryId = value;
                OnPropertychanged("CategoryId");
            }
        }
        public string CategoryName
        {
            get => categoryName;
            set
            {
                categoryName = value;
                OnPropertychanged("CategoryName");
            }
        }

        public string Address
        {
            get => address;
            set
            {
                address = value;
                OnPropertychanged("Address");
            }
        }

        public double Latitude
        {
            get => latitude;
            set
            {
                latitude = value;
                OnPropertychanged("Latitude");
            }
        }

        public double Longitude
        {
            get => longitude;
            set
            {
                longitude = value;
                OnPropertychanged("Longitude");
            }
        }

        public int Distance
        {
            get => distance;
            set
            {
                distance = value;
                OnPropertychanged("Distance");
            }
        }

        public string UserId
        {
            get => userId;
            set
            {
                userId = value;
                OnPropertychanged("UserId");
            }
        }

        private Venue venue;

        [JsonIgnore]
        public Venue Venue
        {
            get => venue;
            set
            {
                venue = value;

                if(venue.categories != null)
                {
                    var firstCategory = venue.categories.FirstOrDefault();

                    CategoryId = firstCategory?.id;
                    CategoryName = firstCategory?.name;
                }
                
                if(venue.location != null)
                {
                    Address = venue.location?.address;
                    Distance = venue.location.distance;
                    Latitude = venue.location.lat;
                    Longitude = venue.location.lng;
                }
                
                VenueName = venue.name;
                UserId = App.CurrentUser?.Id;
                OnPropertychanged("Venue");
            }
        }

        private DateTimeOffset timeStamp;
        [JsonProperty("CREATEDAT")]
        public DateTimeOffset TimeStamp
        {
            get { return timeStamp; }
            set {
                timeStamp = value;
                OnPropertychanged("TimeStamp");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public static async void Insert(Post post)
        {
            await App.postTable.InsertAsync(post);
            await App.MobileService.SyncContext.PushAsync();
        }

        public static async Task<List<Post>> Read()
        {
            var posts = await App.postTable.Where(w => w.UserId == App.CurrentUser.Id).ToListAsync();

            return posts;
        }

        public static Dictionary<string, int> PostCategories(List<Post> posts)
        {
            var categories = (from p in posts
                              orderby p.CategoryId
                              select p.CategoryName).Distinct();

            Dictionary<string, int> categoriesCount = new Dictionary<string, int>();

            foreach (var ii in categories)
            {
                if (ii == null)
                    continue;

                var count = (from post in posts
                             where post.CategoryName == ii
                             select post).ToList().Count;

                categoriesCount.Add(ii, count);
            }

            return categoriesCount;
        }

        public static async void UpdatePost(Post post)
        {
            await App.MobileService.GetTable<Post>().UpdateAsync(post);
        }

        public static async Task<bool> DeletePost(Post post)
        {
            try
            {
                await App.postTable.DeleteAsync(post);
                await App.MobileService.SyncContext.PushAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
       }

        private void OnPropertychanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
