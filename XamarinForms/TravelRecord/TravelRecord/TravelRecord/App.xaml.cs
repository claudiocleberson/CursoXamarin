using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System;
using TravelRecord.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecord
{
    public partial class App : Application
    {
        public static string DataBaseLocation = string.Empty;

        public static User CurrentUser { set; get; }

        public static MobileServiceClient MobileService =
                        new MobileServiceClient(
                        "https://travelrecord1234.azurewebsites.net");

        public static IMobileServiceSyncTable<Post> postTable;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }

        public App(string databaseLocation)
        {
            InitializeComponent();

            DataBaseLocation = databaseLocation;

            MainPage = new NavigationPage(new LoginPage());

            var store = new MobileServiceSQLiteStore(databaseLocation);

            store.DefineTable<Post>();

            MobileService.SyncContext.InitializeAsync(store);

            postTable = MobileService.GetSyncTable<Post>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
