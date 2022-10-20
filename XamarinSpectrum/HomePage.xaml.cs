using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinSpectrum.Services;

namespace XamarinSpectrum
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<Page, string>(this, "SelectedEmployee", (sender, values) =>
            {
                this.SelectedEmployeeText.Text = values;
            });
        }

        protected override void OnAppearing()
        {
            if(App.Current.MainPage.Navigation.NavigationStack.Count < 3)
            DependencyService.Get<IToastService>().ShowToast("Logged in Successfully");
           
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            await App.Navigation.PushAsync(new ListPage());
        }

        async void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {
            DependencyService.Get<IToastService>().ShowToast("Log out successfully");
            await App.Navigation.PopToRootAsync();
        }
    }
}
