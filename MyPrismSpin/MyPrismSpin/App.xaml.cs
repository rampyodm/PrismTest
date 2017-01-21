using MyPrismSpin.Views;
using MyPrismSpin.Navigation;
using Prism.Autofac;
using Prism.Autofac.Forms;

namespace MyPrismSpin
{
    public partial class App : PrismApplication
    {
        public static MyPrismSpinNavigationPage NavigationPage { get; private set; }

        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("MyPrismSpinNavigationPage/MainPage");
            //NavigationService.NavigateAsync("MainPage?title=Hello%20from%20Xamarin.Forms");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<Page2View>();
            Container.RegisterTypeForNavigation<MyPrismSpinNavigationPage>();
        }
    }
}
