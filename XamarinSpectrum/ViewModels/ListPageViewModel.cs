using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinSpectrum.Models;

namespace XamarinSpectrum.ViewModels
{
    public class ListPageViewModel
    {
        ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        public ObservableCollection<Employee> Employees {
            get { return employees; }
            set { employees = value; }
        }

        public ICommand ListSelectedCommand { get; set; }

        public ListPageViewModel()
        {
            employees.Add(new Employee { DisplayName = "Rob Finnerty", Location="MD", Type= "FullTime", Senior = false });
            employees.Add(new Employee { DisplayName = "Bill Wrestler", Location = "AZ", Type = "Contract", Senior = false });
            employees.Add(new Employee { DisplayName = "Geri-Beth Hooper", Location = "LA", Type = "FullTime", Senior = true });
            employees.Add(new Employee { DisplayName = "Keith Joyce-Purdy", Location = "CA", Type = "Contract", Senior = true });
            employees.Add(new Employee { DisplayName = "Sheri Spruce", Location = "TX", Type = "FullTime", Senior = false });
            employees.Add(new Employee { DisplayName = "Burt Indybrick", Location = "FL", Type = "Contract", Senior = true });
            employees.Add(new Employee { DisplayName = "Robert Finlay", Location = "MD", Type = "FullTime", Senior = false });
            employees.Add(new Employee { DisplayName = "James wester", Location = "AZ", Type = "Contract", Senior = false });
            employees.Add(new Employee { DisplayName = "carl Hooper", Location = "LA", Type = "FullTime", Senior = true });
            employees.Add(new Employee { DisplayName = "DB Cooper", Location = "CA", Type = "Contract", Senior = true });
            employees.Add(new Employee { DisplayName = "jonathan smith", Location = "TX", Type = "FullTime", Senior = false });
            employees.Add(new Employee { DisplayName = "Burt Hans", Location = "FL", Type = "Contract", Senior = true });
            employees.Add(new Employee { DisplayName = "Ricky mark", Location = "MD", Type = "FullTime", Senior = false });
            employees.Add(new Employee { DisplayName = "Matt wesley", Location = "AZ", Type = "Contract", Senior = false });
            employees.Add(new Employee { DisplayName = "Gary gerg", Location = "LA", Type = "FullTime", Senior = true });
            employees.Add(new Employee { DisplayName = "Kevin hisneburg", Location = "CA", Type = "Contract", Senior = true });
            employees.Add(new Employee { DisplayName = "Smith murray", Location = "TX", Type = "FullTime", Senior = false });
            employees.Add(new Employee { DisplayName = "kurt cobain", Location = "FL", Type = "Contract", Senior = true });
            ListSelectedCommand = new Command(async (selectedItem) => await ListSelectedCommandAsync(selectedItem));;
        }

        private async Task ListSelectedCommandAsync(object arg)
        {
            Employee employee = (Employee)arg;
            await App.Navigation.PushAsync(new EmployeeDetails(employee));
        }
    }
}
