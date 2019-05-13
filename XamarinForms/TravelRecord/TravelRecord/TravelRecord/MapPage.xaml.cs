using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Essentials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using TravelRecord.Model;
using Xamarin.Forms.Maps;

namespace TravelRecord
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        bool hasLocationPermission = false;
        public MapPage()
        {
            InitializeComponent();

            GetPermissions();

            
        }
        
        private async void GetPermissions()
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                    {
                        await DisplayAlert("Need location", "Gonna need that location", "OK");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
                    //Best practice to always check that the key exists
                    if (results.ContainsKey(Permission.Location))
                        status = results[Permission.Location];
                }

                if (status == PermissionStatus.Granted)
                {
                    Device.BeginInvokeOnMainThread(() => {
                        map.IsShowingUser = true;

                        hasLocationPermission = true;

                        GetLocation();
                    });
                }
                else if (status != PermissionStatus.Unknown)
                {
                    await DisplayAlert("Location Denied", "Can not continue, try again.", "OK");
                }
            }
            catch (Exception ex)
            {

               System.Diagnostics.Debug.WriteLine("Error: " + ex);
            }
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            //using (SQLiteConnection conn = new SQLiteConnection(App.DataBaseLocation))
            //{
            //    conn.CreateTable<Post>();

            //    var posts = conn.Table<Post>().ToList();

            //    DisplayInMap(posts);
            //}

            var posts = await Post.Read();

            DisplayInMap(posts);
        }

        private void DisplayInMap(List<Post> posts)
        {
            foreach(var p in posts)
            {
                try
                {
                    var position = new Position(p.Latitude, p.Longitude);
                    var pin = new Pin()
                    {
                        Type = PinType.SavedPin,
                        Position = position,
                        Label = p.VenueName,
                        Address = p.Address
                    };

                    map.Pins.Add(pin);
                }
                catch(NullReferenceException nrf)
                {
                    System.Diagnostics.Debug.WriteLine("Null ref " + nrf);
                }
                catch(Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exception  " + ex);
                }
            }
        }

        private async void GetLocation()
        {
            if (hasLocationPermission)
            {
                var position = await Geolocation.GetLocationAsync();
                if(position!= null)
                {
                    var center = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);
                    var span = new Xamarin.Forms.Maps.MapSpan(center, 1, 1);
                    map.MoveToRegion(span);
                }
            }
        }

    }
}