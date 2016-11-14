using Template10.Mvvm;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;

namespace ZzaDesktop.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public void GotoCustomerList() =>
            NavigationService.Navigate(typeof(Views.CustomerListView));

        public void GotoOrderPrep() =>
            NavigationService.Navigate(typeof(Views.OrderPrepView));

        public void GotoSettings() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 0);

        public void GotoPrivacy() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 1);

        public void GotoAbout() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 2);

    }
}

