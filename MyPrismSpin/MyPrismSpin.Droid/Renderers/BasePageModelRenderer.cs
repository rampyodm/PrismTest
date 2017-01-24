using System;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Views;
using MyPrismSpin;
using MyPrismSpin.Droid;
using MyPrismSpin.Navigation;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(MyPrismSpinNavigationPage), typeof(BasePageModelRenderer))]
namespace MyPrismSpin.Droid
{
    public class BasePageModelRenderer : NavigationPageRenderer
    {
        private bool _initialized = false;

        protected override void OnElementChanged(ElementChangedEventArgs<NavigationPage> e)
        {
            base.OnElementChanged(e);

            ApplyTransparency();
        }

        protected override bool DrawChild(Android.Graphics.Canvas canvas, Android.Views.View child, long drawingTime)
        {
            ApplyTransparency();

            return base.DrawChild(canvas, child, drawingTime);
        }

        void ApplyTransparency()
        {
            if (!_initialized)
            {
                var activity = ((FormsAppCompatActivity)Context);
                activity.SetStatusBarColor(Android.Graphics.Color.Transparent);

                Window window = activity.Window;
                if (Build.VERSION.SdkInt > BuildVersionCodes.Kitkat)
                {
                    window.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.LayoutStable | (StatusBarVisibility)SystemUiFlags.LayoutFullscreen;
                }
                else if (Build.VERSION.SdkInt == BuildVersionCodes.Kitkat)
                {
                    window.SetFlags(WindowManagerFlags.TranslucentStatus, WindowManagerFlags.TranslucentStatus);
                }

                var backgroundString = ((MyPrismSpinNavigationPage)Element).CurrentPage.BackgroundImage;
                ((MyPrismSpinNavigationPage)Element).CurrentPage.BackgroundImage = null;
                ((MyPrismSpinNavigationPage)Element).BackgroundColor = Xamarin.Forms.Color.Transparent;
                var backgroundImage = backgroundString != null ? activity.Resources.GetDrawable(backgroundString) : new ColorDrawable(Android.Graphics.Color.White);
                window.SetBackgroundDrawable(backgroundImage != null ? backgroundImage : new ColorDrawable(Android.Graphics.Color.White));

                _initialized = true;
            }
        }
    }
}
