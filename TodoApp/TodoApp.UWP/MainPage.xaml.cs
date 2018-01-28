using TodoApp.Interface;
using TodoApp.UWP.Helper;
using Xamarin.Forms;

namespace TodoApp.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            DependencyService.Register<IFileHelper, FileHelper>();
            DependencyService.Register<ITextToSpeech, SpeechText>();
            LoadApplication(new TodoApp.App());
        }
    }
}
