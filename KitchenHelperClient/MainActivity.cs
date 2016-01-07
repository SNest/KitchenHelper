using Android.App;
using Android.OS;

namespace KitchenHelperClient
{
    [Activity(Label = "KitchenHelperClient", MainLauncher = true, Icon = "@drawable/icon",
        Theme = "@style/Theme.MyTheme")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
        }
    }
}