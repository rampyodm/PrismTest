using System;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace MyPrismSpin
{
    public abstract class BasePageModel : BindableBase, INavigationAware
    {
        public BasePageModel()
        {
            
        }

        public abstract void OnNavigatedFrom(NavigationParameters parameters);

        public abstract void OnNavigatedTo(NavigationParameters parameters);
    }
}

