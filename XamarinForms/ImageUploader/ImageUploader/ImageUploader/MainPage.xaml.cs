using Microsoft.WindowsAzure.Storage;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ImageUploader
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void SelectButton_Clicked(object sender, EventArgs e)
        {

            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Error", "This is not supported on your device", "OK");
                return;

            }

            var mediaOptions = new PickMediaOptions()
            {
                PhotoSize = PhotoSize.Medium
            };

            var selectedImageFile = await CrossMedia.Current.PickPhotoAsync(mediaOptions);

            if(selectedImageFile == null)
            {

                await DisplayAlert("Error", "No image selected", "OK");
                return;
            }

            selectedImage.Source = ImageSource.FromStream(() => selectedImageFile.GetStream());

            UploadImage(selectedImageFile.GetStream());
        }

        private async void UploadImage(Stream stream)
        {

            var account = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=travelrecordblob;AccountKey=8pV+QOkUjZC0dS44t4U3f3CaxDUNVKP+pEbJJuOU3qFuWKHgh7F11/ztnv9M/OkNN7E9OPdjV1S/tHCenR6vRA==;EndpointSuffix=core.windows.net");

            var client = account.CreateCloudBlobClient();

            var container = client.GetContainerReference("imagecontainer");

            await container.CreateIfNotExistsAsync();

            var name = Guid.NewGuid().ToString();

            var blockBlob = container.GetBlockBlobReference(name + ".jpg");

            await blockBlob.UploadFromStreamAsync(stream);

            var url = blockBlob.Uri.OriginalString;

            System.Diagnostics.Debug.WriteLine(" File Uploaded " + url);
        }
    }
}
