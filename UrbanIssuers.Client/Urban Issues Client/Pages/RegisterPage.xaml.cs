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
    using Urban_Issues_Client.Data;
    using Urban_Issues_Client.Data.Models;
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            this.InitializeComponent();
        }

        private void RegisterButtonClick(object sender, RoutedEventArgs e)
        {
            RegisterUserModel model = new RegisterUserModel();
            model.Email = this.EmailInput.Text;
            model.Password = this.PasswordInput.Password;
            model.ConfirmPassword = this.ConfirmPasswordInput.Password;

            Data.RegisterUser(model);   
        }
        
    }
}
