using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using SlideOverKit;
using MyPrismSpin.Views;

namespace MyPrismSpin.ViewModels
{
    public class MainPageViewModel : BasePageModel, IMenuContainerPage
    {
        INavigationService _navigationService;

        public ICommand GoToNextPage;
        public DelegateCommand NavigateCommand
        {
            get; private set;
        }

        public DelegateCommand OpenMenuCommand
        {
            get; private set;
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public SlideMenuView SlideMenu { get; set; }
        public Action ShowMenuAction { get; set; }
        public Action HideMenuAction { get; set; }

        public MainPageViewModel(INavigationService navigationService)
        {
            this.SlideMenu = new RightSideMasterPage();

            _navigationService = navigationService;
            GoToNextPage = new DelegateCommand(Navigate);
            NavigateCommand = new DelegateCommand(Navigate);
            OpenMenuCommand = new DelegateCommand(OpenMenu);

        }

        private void OpenMenu()
        {
            if (ShowMenuAction != null)
                ShowMenuAction();
        }

        private void Navigate()
        {
            _navigationService.NavigateAsync("Page2View");
        }

        public override void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";

        }
    }
}
