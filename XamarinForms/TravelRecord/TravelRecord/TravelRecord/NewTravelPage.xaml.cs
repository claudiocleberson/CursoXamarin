using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecord.Model;
using TravelRecord.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecord
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTravelPage : ContentPage
    {
        NewTravelVM newTravelVM;
        public NewTravelPage()
        {
            InitializeComponent();

            newTravelVM = new NewTravelVM();

            BindingContext = newTravelVM; 
        }


        protected async override void OnAppearing()
        {
            base.OnAppearing();

             var loc = await Xamarin.Essentials.Geolocation.GetLocationAsync();

            var venues = await Venue.GetVenues(loc.Latitude, loc.Longitude);

            venueListView.ItemsSource = venues;
        }
    }
}