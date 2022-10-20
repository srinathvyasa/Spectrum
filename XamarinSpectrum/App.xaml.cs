using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinSpectrum.Services;

namespace XamarinSpectrum
{
    public partial class App : Application
    {
        public static INavigation Navigation { get; set; }
        public static bool EmployeeSelected { get; set; }
        public App()
        {
            InitializeComponent();

            var rootPage = new NavigationPage(new MainPage());
            Navigation = rootPage.Navigation;
            MainPage = rootPage;
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
