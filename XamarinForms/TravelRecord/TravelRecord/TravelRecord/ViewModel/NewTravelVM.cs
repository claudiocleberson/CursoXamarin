using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TravelRecord.Model;
using TravelRecord.ViewModel.Commands;

namespace TravelRecord.ViewModel
{
    public class NewTravelVM : INotifyPropertyChanged
    {

        public PostCommand PostCommand { set; get; }

        private string experience;
        private Venue venue;


        public Venue Venue
        {
            get => venue;
            set
            {
                venue = value;
                Post = new Post
                {
                    Experience = this.Experience,
                    Venue = this.Venue
                };
                OnPropertyChanged("Venue");
            }
        }

        public NewTravelVM()
        {
            PostCommand = new PostCommand(this);
            Venue = new Venue();
            Post = new Post();
        }

        private Post post;

        public Post Post
        {
            get { return post; }
            set
            {
                post = value;
                OnPropertyChanged("Post");
            }
        }
             
        public string Experience
        {
            get { return experience; }
            set
            {
                experience = value;
                Post = new Post
                {
                    Experience = this.Experience,
                    Venue = this.Venue
                };
                OnPropertyChanged("Experience");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        public async void PublishPost(Post post)
        {
            try
            {

                //using (SQLiteConnection conn = new SQLiteConnection(App.DataBaseLocation))
                //{
                //    conn.CreateTable<Post>();

                //    int rows = conn.Insert(post);

                //    conn.Close();

                //    if (rows > 0)
                //    {
                //        DisplayAlert("Success", "Experience successfully inserted", "OK");

                //        experienceEntry.Text = "";
                //    }
                //    else
                //        DisplayAlert("Failure", "Something went wrong!", "Cancel");
                //}

                Post.Insert(post);

                await App.Current.MainPage.DisplayAlert("Success", "Experience successfully inserted", "OK");

            }
            catch (NullReferenceException nre)
            {
                await App.Current.MainPage.DisplayAlert("Failure", "Something went wrong!", "Cancel");
                System.Diagnostics.Debug.WriteLine("Error null reference " + nre);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Failure", "Something went wrong!", "Cancel");
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }
    }
}
