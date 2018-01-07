
using Android.App;
using Android.Content.PM;
using Android.OS;
using TodoApp.Interface;
using Xamarin.Forms;

namespace TodoApp.Droid
{
    [Activity(Label = "TodoApp", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            DependencyService.Register<IFileHelper, FileHelper>();
            DependencyService.Register<ITextToSpeech, TodoTextToSpeech>();
            
            Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}

