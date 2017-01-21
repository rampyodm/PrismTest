using MyPrismSpin.Views;
using MyPrismSpin.Navigation;
using Prism.Autofac;
using Prism.Autofac.Forms;
using Autofac;
using MyPrismSpin.ViewModels;
using Xamarin.Forms;
using MyPrismSpin.Bootstrapping;

namespace MyPrismSpin
{
    public partial class App : PrismApplication
    {
        private IContainer _container;

        public static MyPrismSpinNavigationPage NavigationPage { get; private set; }

        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            //NavigationService.NavigateAsync("MainPage");
            NavigationService.NavigateAsync("MyMasterDetailPage/MyPrismSpinNavigationPage/MainPage");
            //NavigationService.NavigateAsync("MainPage?title=Hello%20from%20Xamarin.Forms");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>("MainPage");
            Container.RegisterTypeForNavigation<Page2View>("Page2View");
            Container.RegisterTypeForNavigation<MyPrismSpinNavigationPage>("MyPrismSpinNavigationPage");
            Container.RegisterTypeForNavigation<NavigationPage>("NavigationPage");
            Container.RegisterTypeForNavigation<MyMasterDetailPage>();
        }

        protected override Autofac.IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();

            ConfigureContainer(builder);

            _container = builder.Build();

            return _container;
        }

        private void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<ViewModelModule>();
        }
    }
}
