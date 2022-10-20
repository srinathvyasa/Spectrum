using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinSpectrum.Models;
using XamarinSpectrum.Services;

namespace XamarinSpectrum.ViewModels
{
    public class EmployeeDetailsViewModel
    {

        public ICommand SelectEmployeeCommmand { get; set; }
        public EmployeeDetailsViewModel(Employee selectedEmployee )
        {
            SelectEmployeeCommmand = new Command(async (selectedItem) => await SelectEmployeeCommmandAsync(selectedEmployee)); ;
        }

        private async Task SelectEmployeeCommmandAsync(object arg)
        {
            App.EmployeeSelected = true;
            var selectedEmployee = arg as Employee;
            DependencyService.Get<IToastService>().ShowToast($"Selected Employee: {selectedEmployee.DisplayName}");

            await App.Navigation.PushAsync(new HomePage());
        }
    }
}
