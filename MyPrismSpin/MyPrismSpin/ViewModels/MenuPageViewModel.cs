using System;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace MyPrismSpin.ViewModels
{
    public class MenuPageViewModel : ContentPage
    {
        INavigationService _navigationService;

        public ICommand GoToNextPage;
        public DelegateCommand NavigateCommand
        {
            get; private set;
        }

        public MenuPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            GoToNextPage = new DelegateCommand(Navigate);
        }

        private void Navigate()
        {
            _navigationService.NavigateAsync("Page2View");
        }
    }
}

