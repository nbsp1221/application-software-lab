using System;
using KLASMobileApp.Net;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KLASMobileApp
{
    public partial class App : Application
    {
        public static RestManager RestManager { get; private set; }

        public App()
        {
            InitializeComponent();

            RestManager = new RestManager(new RestService());

            MainPage = new NavigationPage(new SplashPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
