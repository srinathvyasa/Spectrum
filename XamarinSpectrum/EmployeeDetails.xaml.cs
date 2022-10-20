using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinSpectrum.Models;
using XamarinSpectrum.ViewModels;

namespace XamarinSpectrum
{
    public partial class EmployeeDetails : ContentPage
    {
        public EmployeeDetailsViewModel vm;
        Employee selected = new Employee();
        public EmployeeDetails(Employee selectedemployee)
        {
            BindingContext = vm = new EmployeeDetailsViewModel(selectedemployee);
            InitializeComponent();
            selected = selectedemployee;
            TestData();
            
        }

        public void TestData()
        {
            EmployeeName.Text = "Employee Name:" + selected.DisplayName;
            EmployeeLocation.Text = "Employee Location:" + selected.Location;
            EmploymentType.Text = "Employee Type:" + selected.Type;
        }

        protected override void OnAppearing()
        {
            if (App.EmployeeSelected == true)
            {
                MessagingCenter.Send<Page, string>(this, "SelectedEmployee", $"Employee of the Month : {selected.DisplayName}");
                App.EmployeeSelected = false;
            }
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            if (App.EmployeeSelected == true)
            {
                MessagingCenter.Send<Page, string>(this, "SelectedEmployee", $"Employee of the Month : {selected.DisplayName}");
                App.EmployeeSelected = false;
            }
            base.OnDisappearing();
        }
    }
}
