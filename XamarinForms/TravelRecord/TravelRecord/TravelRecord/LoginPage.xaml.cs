using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecord.Model;
using TravelRecord.ViewModel;
using Xamarin.Forms;

namespace TravelRecord
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class LoginPage : ContentPage
    {

        MainVM mainViewModel;

        public LoginPage()
        {
            InitializeComponent();

            mainViewModel = new MainVM();

            BindingContext = mainViewModel;

            var assembly = typeof(LoginPage);
            iconImage.Source = ImageSource.FromResource("TravelRecord.Assets.Images.plane.png", assembly);
        }
    }
}
