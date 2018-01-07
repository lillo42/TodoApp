using TodoApp.Interface;
using Xamarin.Forms;

namespace TodoApp.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            DependencyService.Register<IFileHelper, FileHelper>();
            DependencyService.Register<ITextToSpeech, TodoTextToSpeech>();

            LoadApplication(new TodoApp.App());
        }
    }
}
