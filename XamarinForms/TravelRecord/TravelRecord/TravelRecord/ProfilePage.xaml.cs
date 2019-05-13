using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecord.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecord
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //using (SQLiteConnection conn = new SQLiteConnection(App.DataBaseLocation))
            //{
                var postTable = await Post.Read();

            //Method to aquire only the categories from a table using Linq Distinct() method.
                var categories = Post.PostCategories(postTable);

                categoryListView.ItemsSource = categories;

                postCounterLabel.Text = postTable.Count.ToString();
            //
        }
    }
}