using System;
using Autofac;
using MyPrismSpin.ViewModels;

namespace MyPrismSpin.Bootstrapping
{
    public class ViewModelModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
       
            builder.RegisterType<MainPageViewModel>();
            builder.RegisterType<MenuPageViewModel>();
            builder.RegisterType<Page2ViewModel>();
            builder.RegisterType<PrismMasterDetailPage1ViewModel>();
            builder.RegisterType<BasePageModel>();
        }
    }
}
