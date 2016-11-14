using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;
using Zza.Data;

namespace ZzaDesktop.ViewModels
{
    public class OrdersViewModel : ViewModelBase
    {
        private Customer customer;
        public Customer Customer
        {
            get { return customer; }
            set { Set(ref customer, value); }
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            Customer = (state.ContainsKey(nameof(Customer))) ? state[nameof(Customer)] as Customer : parameter as Customer;
            await Task.CompletedTask;
        }

    }
}
