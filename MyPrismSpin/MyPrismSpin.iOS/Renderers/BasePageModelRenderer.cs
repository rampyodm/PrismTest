using System;
using MyPrismSpin.iOS;
using MyPrismSpin.Navigation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MyPrismSpinNavigationPage), typeof(BasePageModelRenderer))]
namespace MyPrismSpin.iOS
{
    public class BasePageModelRenderer : NavigationRenderer
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            StyleNavBar();
        }

        private void StyleNavBar()
        {
            var navigationPage = ((MyPrismSpinNavigationPage)Element);
            var backgroundString = "cloudBackground";//navigationPage.CurrentPage.BackgroundImage;
            navigationPage.CurrentPage.BackgroundImage = null;
            var backgroundImage = backgroundString != null ? UIImage.FromBundle(backgroundString) : new UIImage();

            UINavigationBar.Appearance.SetBackgroundImage(backgroundImage, UIBarMetrics.Default);
            UINavigationBar.Appearance.ShadowImage = new UIImage();
            UINavigationBar.Appearance.TintColor = Color.White.ToUIColor();

            navigationPage.CurrentPage.BackgroundColor = Color.Transparent;
            //View.BackgroundColor = UIColor.FromPatternImage(backgroundImage);
            UIWindow.Appearance.BackgroundColor = UIColor.FromPatternImage(backgroundImage);
        }
    }
}
