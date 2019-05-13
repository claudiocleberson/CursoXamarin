using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecord.Helpers;
using TravelRecord.Model;
using TravelRecord.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecord
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPage : ContentPage
    {
        HistoryVM historyVM;
        public HistoryPage()
        {
            InitializeComponent();

            historyVM = new HistoryVM();

            BindingContext = historyVM;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //using (SQLiteConnection conn = new SQLiteConnection(App.DataBaseLocation))
            //{
            //    conn.CreateTable<Post>();

            //    var posts = conn.Table<Post>().ToList();

            //    historyListView.ItemsSource = posts;
            //}

            await historyVM.UpdatePosts();

            await AzureAppServiceHelper.SyncAsync();
        }

        private void HistoryListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var post = e.SelectedItem as Post;

            Navigation.PushAsync(new PostDetails(post));

            historyListView.SelectedItem = null;
        }

        private async void DeleteItem_Clicked(object sender, EventArgs e)
        {
            var post = sender as MenuItem;
            var p = post.CommandParameter as Post;
            if (p != null)
                await historyVM.DeletePost(p);
        }

        private async void HistoryListView_Refreshing(object sender, EventArgs e)
        {
            await historyVM.UpdatePosts();

            await AzureAppServiceHelper.SyncAsync();

            historyListView.IsRefreshing = false;
        }
    }
}