using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Entity;
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

        private BaseViewModel ViewModel => BindingContext as BaseViewModel;

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (ViewModel == null)
                return;

            await ViewModel.LoadAsync();
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
