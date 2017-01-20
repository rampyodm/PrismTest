using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;

namespace MyPrismSpin.ViewModels
{
    public class PrismMasterDetailPage1ViewModel : BindableBase
    {
        private INavigationService _navigationService;
        public DelegateCommand<string> NavigationCommand => new DelegateCommand<string>(Navigation);

        private void Navigation(string page)
        {
            _navigationService.NavigateAsync(page);
        }
        public PrismMasterDetailPage1ViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            
        }
    }
}
