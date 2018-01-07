
using Xamarin.Forms;

namespace TodoApp
{
    public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            Resources = new ResourceDictionary
            {
                { "primaryGreen", Color.FromHex("91CA47") },
                { "primaryDarkGreen", Color.FromHex("6FA22E") }
            };

            MainPage = new TodoApp.MainPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
