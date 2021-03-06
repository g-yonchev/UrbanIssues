﻿using System;
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
    using Windows.UI.Notifications;
    using Data;
    using Data.Models;
    using Newtonsoft.Json;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private async void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            LoginUserModel model = new LoginUserModel();
            model.Username = this.LoginEmailInput.Text;
            model.Password = this.LoginPasswordInput.Password;

            var response = await Data.LoginUser(model);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var token = JsonConvert.DeserializeObject<LoginResultToken>(content);
                this.Frame.Navigate(typeof(HomePage), token);
            }
            else
            {
                this.LoginResult.Text = "Wrong email or password.";
            }
        }

        private async void RedirectToRegister(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (RegisterPage));
        }

        //public static string RequestToken()
        //{
        //    return 
        //}
    }

    public class LoginResultToken
    {

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }
}
