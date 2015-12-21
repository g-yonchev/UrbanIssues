using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Capture;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Urban_Issues_Client.Pages
{
    using Data;
    using Data.Models;
    using Newtonsoft.Json;

    /// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class CreateIssuePage : Page
    {
        private string token;
		private Geolocator geolocator;
		private CameraCaptureUI camera;
		private IList<string> pictures = new List<string>();

		public CreateIssuePage()
		{
			this.InitializeComponent();
		}

		// Camera
		private async void OnAddPictureButtonClick(object sender, RoutedEventArgs e)
		{
			this.camera = new CameraCaptureUI();
			var photo = await this.camera.CaptureFileAsync(CameraCaptureUIMode.Photo);
			var img = new Image();
			img.Width = 200;
			img.Height = 200;
			img.Margin = new Thickness(10.0);
			img.Source = new BitmapImage(new Uri(photo.Path));
			this.PicturesToAdd.Children.Add(img);

			// collect images
			this.pictures.Add(photo.Path);
		}

		// Location
		private async void OnLocationButtonClick(object sender, RoutedEventArgs e)
		{
			this.geolocator = new Geolocator();
			var geoposition = await this.geolocator.GetGeopositionAsync();
			var lat = geoposition.Coordinate.Latitude;
			var lon = geoposition.Coordinate.Longitude;

			this.LocationLatitude.Text = lat.ToString();
			this.LocationLongitude.Text = lon.ToString();
		}

		// create Issue
		private void OnCreateIssueButtonClick(object sender, RoutedEventArgs e)
		{
			//send data
			//this.pictures;
			//this.Category;
			//this.Description;
			//this.LocationLatitude;
			//this.LocationLongitude;

			// navigate to this Issue
		}

		// cancel
		private void OnCancelIssueButtonClick(object sender, RoutedEventArgs e)
		{
			//this.Frame.Navigate(typeof(HomePage));
			// or back
		}

		private void OnChoosePictureButtonClick(object sender, RoutedEventArgs e)
		{
			// open gallery
		}

		private void OnAddUrlButtonClick(object sender, RoutedEventArgs e)
		{
			var url = this.Url.Text;
			var img = new Image();
			img.Width = 200;
			img.Height = 200;
			img.Margin = new Thickness(10.0);
			img.Source = new BitmapImage(new Uri(url));
			this.PicturesToAdd.Children.Add(img);

			// collect images
			this.pictures.Add(url);
		}

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            this.token = e.Parameter.ToString();
        }

        private async void AddNewIssue(object sender, RoutedEventArgs e)
	    {
	        AddIssueModel model = new AddIssueModel();
            model.Title = this.TitleIssue.Text;
            model.Category = this.Category.Text;
            model.City = this.City.Text;
            model.Description = this.Description.Text;
            var result = await Data.AddIssue(model, this.token);
            if (!result)
            {
                //this.Result.Text = "Wrong email or password.";
            }
            else
            {
                //this.Result.Text = "Successful registration";
                this.Frame.Navigate(typeof(HomePage));
            }
        }

    }
}
