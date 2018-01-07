using System;
using TodoApp.Entity;
using TodoApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoListPage : ContentPage
    {
        public TodoListPage()
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

        private void TbiItem_Clicked(object sender, EventArgs e)
        {
            (ViewModel as TodoListViewModel).SelectItem.Execute(new TodoItem());
        }

        private void LstTodo_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {   
            if (e.SelectedItem != null)
            {
                (ViewModel as TodoListViewModel).SelectItem.Execute(e.SelectedItem as TodoItem);
            }
        }
    }
}