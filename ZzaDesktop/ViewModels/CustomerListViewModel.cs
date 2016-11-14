using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Zza.Data;
using ZzaDesktop.Services;

namespace ZzaDesktop.ViewModels
{
    public class CustomerListViewModel : ViewModelBase
    {
        ICustomersRepository repository = new CustomersRepository();

        public CustomerListViewModel()
        {
            PlaceOrderCommand = new DelegateCommand<Customer>(OnPlaceOrder);
            EditCustomerCommand = new DelegateCommand<Customer>(OnEditingCustomer);
            AddCustomerCommand = new DelegateCommand(OnAddingCustomer);
        }

        private ObservableCollection<Customer> customers;
        public ObservableCollection<Customer> Customers
        {
            get { return customers; }
            set { Set(ref customers, value); }
        }

        public async void LoadCustomersAsync()
        {
            Customers = new ObservableCollection<Customer>(await repository.GetCustomersAsync());
        }

        public DelegateCommand<Customer> PlaceOrderCommand
        {
            get;
            private set;
        }

        public DelegateCommand<Customer> EditCustomerCommand
        {
            get;
            private set;
        }

        public DelegateCommand AddCustomerCommand
        {
            get;
            private set;
        }
        private void OnPlaceOrder(Customer customer)
        {
            NavigationService.Navigate(typeof(Views.OrdersView), customer);
        }

        private void OnEditingCustomer(Customer customer)
        {
            NavigationService.Navigate(typeof(Views.AddEditCustomerView), customer);
        }

        private void OnAddingCustomer()
        {
            NavigationService.Navigate(typeof(Views.AddEditCustomerView));
        }

    }
}
