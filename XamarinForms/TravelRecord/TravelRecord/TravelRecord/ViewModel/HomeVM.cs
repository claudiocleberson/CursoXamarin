using System;
using System.Collections.Generic;
using System.Text;
using TravelRecord.ViewModel.Commands;

namespace TravelRecord.ViewModel
{
    public class HomeVM
    {
        public NavigationCommands NavCommand { get; set; }

        public HomeVM()
        {
            NavCommand = new NavigationCommands(this);
        }

        public void Navigate()
        {
            App.Current.MainPage.Navigation.PushAsync(new NewTravelPage());
        }
    }
}
