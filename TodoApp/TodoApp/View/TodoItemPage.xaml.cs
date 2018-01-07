﻿using System;
using System.Diagnostics;
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

        private void TbiItem_Clicked(object sender, EventArgs e)
        {
            Debug.WriteLine(nameof(TbiItem_Clicked));
        }

        private void LstTodo_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Debug.WriteLine(nameof(LstTodo_ItemSelected));
        }
    }
}
