using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TodoApp.Data;
using Xamarin.Forms;

namespace TodoApp.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        private static Lazy<TodoDbContext> _lazyContext = new Lazy<TodoDbContext>(() => new TodoDbContext());
        protected TodoDbContext DbContext => _lazyContext.Value;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChange([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName]string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;
            storage = value;
            OnPropertyChange(propertyName);
            return true;
        }

        public virtual Task LoadAsync() => Task.CompletedTask;

        protected async Task PushAsync<TViewModel>(params object[] args)
            where TViewModel : BaseViewModel
        {
            try
            {
                Type viewModelType = typeof(TViewModel);
                string viewModelTypeName = viewModelType.Name;
                int viewModelWordLength = "ViewModel".Length;
                string viewTypeName = $"TodoApp.ViewModel.{viewModelTypeName.Substring(0, viewModelTypeName.Length - viewModelWordLength)}Page";
                Type viewType = Type.GetType(viewTypeName);
                Page page = Activator.CreateInstance(viewType) as Page;

                var viewModel = Activator.CreateInstance(viewModelType, args);
                if (page != null)
                    page.BindingContext = viewModel;
                await App.Current.MainPage.Navigation.PushAsync(page);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                throw;
            }
        }
    }
}
