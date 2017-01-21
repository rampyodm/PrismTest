using System;
using Prism.Commands;
using Prism.Navigation;

namespace MyPrismSpin.ViewModels
{
    public class MasterDetailPageModel
    {
        private INavigationService _navigationService;


        public DelegateCommand<string> NavigationCommand => new DelegateCommand<string>(Navigation);


        public MasterDetailPageModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        private void Navigation(string page)
        {
            _navigationService.NavigateAsync(page);
        }
    }
}
