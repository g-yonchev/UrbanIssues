using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UrbanIssues.Pages;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace UrbanIssues.Views
{
	public sealed partial class BottomTabBar : UserControl
	{
		public BottomTabBar()
		{
			this.InitializeComponent();
		}

		private void OnRegisterButtonClick(object sender, RoutedEventArgs e)
		{
			(Window.Current.Content as Frame).Navigate(typeof(RegisterPage));
		}

		private void OnLogInButtonClick(object sender, RoutedEventArgs e)
		{
			(Window.Current.Content as Frame).Navigate(typeof(LoginPage));
		}

		private void OnLogOutButtonClick(object sender, RoutedEventArgs e)
		{
			(Window.Current.Content as Frame).Navigate(typeof(MainPage));
		}

		private void OnAboutButtonClick(object sender, RoutedEventArgs e)
		{
			(Window.Current.Content as Frame).Navigate(typeof(AboutPage));
		}
	}
}
