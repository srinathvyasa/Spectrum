using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinSpectrum.Models;

namespace XamarinSpectrum
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            if (String.IsNullOrEmpty(Username.Text) || string.IsNullOrEmpty(Password.Text))
                await App.Current.MainPage.DisplayAlert("Error", "Username or Password is Empty", "OK");
            else if (Username.Text != Password.Text)
                await App.Current.MainPage.DisplayAlert("Error", "Username or Password is Invalid", "OK");
            else if (Username.Text == Password.Text)
            await App.Navigation.PushAsync(new HomePage()); 
        }

        protected override void OnAppearing()
        {
            Username.Text = string.Empty;
            Password.Text = string.Empty;
            base.OnAppearing();
        }
    }
}
