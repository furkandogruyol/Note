using System;
using ListToDoo.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListToDoo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
         
            if (Application.Current.Properties.ContainsKey("user"))
            {
                MainPage = new NavigationPage(new MainPage())
                {
                    BarBackgroundColor = Color.FromHex("#222831"),
                    BarTextColor = Color.FromHex("#eeeeee")
                };
            }
            else
            {
                MainPage = new NavigationPage(new Login())
                {
                    BarBackgroundColor = Color.FromHex("#222831"),
                    BarTextColor = Color.FromHex("#eeeeee")
                };
            }
            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
