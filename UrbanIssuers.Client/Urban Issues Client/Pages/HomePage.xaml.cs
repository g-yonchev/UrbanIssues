using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Urban_Issues_Client.Pages
{
    using Data;
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        private string token;
        public HomePage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var parameter = e.Parameter as LoginResultToken;
            this.token = parameter.AccessToken;
            GetIssues(this.token);
        }

        private async void GetIssues(string token)
        {
            var issues = await Data.GetIssues(token);
        }

		private void OnCreateIssueButtonClick(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(CreateIssuePage));
		}
	}
}
