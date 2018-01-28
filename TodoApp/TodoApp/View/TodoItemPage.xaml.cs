using TodoApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoItemPage : ContentPage
    {
        public TodoItemPage()
        {
            InitializeComponent();
        }

        private TodoItemViewModel ViewModel => BindingContext as TodoItemViewModel;

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (ViewModel == null)
                return;
            Title = ViewModel.Title;
            await ViewModel.LoadAsync();
        }
    }
}