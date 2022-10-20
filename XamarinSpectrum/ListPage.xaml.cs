using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinSpectrum.ViewModels;

namespace XamarinSpectrum
{
    public partial class ListPage : ContentPage
    {
        public ListPageViewModel vm;
        public ListPage()
        {
            BindingContext = vm = new ListPageViewModel();
            InitializeComponent();
        }
    }
}
