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
    using System.ComponentModel;
    using Data;
    using Data.Models;
    using Newtonsoft.Json;
    using ViewModels;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page, INotifyPropertyChanged
    {
        public IList<IssueViewModel> Issues { get; set; }

        private string token;

        public HomePage()
        {
            this.Issues = new List<IssueViewModel>();
            //this.Issues.Add(new IssueViewModel()
            //{
            //    Title = "Petko"
            //});
            this.DataContext = this;
            this.InitializeComponent();
            //GetIssues(token);
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            var parameter = e.Parameter as LoginResultToken;
            this.token = parameter.AccessToken;
            var issues = await Data.GetIssues(token);
            var result = await issues.Content.ReadAsStringAsync();
            var resultConverted = JsonConvert.DeserializeObject<List<IssueViewModel>>(result);
            this.Issues = resultConverted;
            OnPropertyChanged("Issues");
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler == null) return;
            handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}