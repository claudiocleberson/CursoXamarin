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
    public partial class PostDetails : ContentPage
    {

        private Post currentPost;
        public PostDetails(Post post)
        {
            InitializeComponent();
            currentPost = post;

            contentEditor.Text = currentPost.Experience;
        }

        private async void UpdateButton_Clicked(object sender, EventArgs e)
        {
            if (currentPost == null)
                return;

            //using (SQLiteConnection conn = new SQLiteConnection(App.DataBaseLocation))
            //{
            //    conn.CreateTable<Post>();

            //    currentPost.Experience = contentEditor.Text;

            //    int rows = conn.Update(currentPost);

            //    if (rows > 0)
            //    {
            //        await DisplayAlert("Success", "Experience successfully Updated", "OK");

            //        contentEditor.Text = "";

            //        await Navigation.PopAsync();
            //    }
            //    else
            //        await DisplayAlert("Failure", "Something went wrong!", "Cancel");
            //}

            ///var posts = await App.MobileService.GetTable<Post>().Where(w => w.UserId == App.CurrentUser.Id).ToListAsync();

            currentPost.Experience = contentEditor.Text;

            Post.UpdatePost(currentPost);

            await DisplayAlert("Success", "Experience successfully Updated", "OK");

        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            if (currentPost == null)
                return;

            Post.DeletePost(currentPost);

            await DisplayAlert("Success", "Experience successfully Deleted", "OK");

            //using (SQLiteConnection conn = new SQLiteConnection(App.DataBaseLocation))
            //{
            //    conn.CreateTable<Post>();

            //    int rows = conn.Delete(currentPost);

            //    if (rows > 0)
            //    {
            //        await DisplayAlert("Success", "Experience successfully Deleted", "OK");

            //        contentEditor.Text = "";

            //        await Navigation.PopAsync();
            //    }
            //    else
            //        await DisplayAlert("Failure", "Something went wrong!", "Cancel");
            //}
        }
    }
}