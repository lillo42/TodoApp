using TodoApp.Models;
using TodoApp.ViewModel;
using Xamarin.Forms;

namespace TodoApp
{
    public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            BindingContext = new MainViewModel();
        }

        private MainViewModel ViewModel => BindingContext as MainViewModel;

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (ViewModel == null)
                return;
            Title = ViewModel.Title;
            await ViewModel.LoadAsync();
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is TodoItem item)
                ViewModel?.EditTodoItemCommand.Execute(item);
        }
    }
}
