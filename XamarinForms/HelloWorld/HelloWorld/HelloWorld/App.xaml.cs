using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Linq;
using Xamarin.Forms.Xaml;
using System.Globalization;
using System.Collections.Generic;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace HelloWorld
{
    public partial class App : Xamarin.Forms.Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected async override void OnStart()
        {
            base.OnStart();
        }

        protected async override void OnSleep()
        {
            base.OnSleep();
        }

        protected async override void OnResume()
        {
            base.OnResume();
        }
    }
}
