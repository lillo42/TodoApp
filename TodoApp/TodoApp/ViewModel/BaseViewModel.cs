using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TodoApp.DbContext;
using TodoApp.Interface;
using Xamarin.Forms;

namespace TodoApp.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        private TodoDbContext _database;

        protected TodoDbContext Database
        {
            get
            {
                if(_database == null)
                {
                    _database = new TodoDbContext(DependencyService.Get<IFileHelper>().GetLocalFilePath("TodoSQLite.db3"));
                }
                return _database;
            }
        }

        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChange([CallerMemberName]string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName]string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;
            storage = value;
            OnPropertyChange(propertyName);
            return true;
        }

        public virtual Task LoadAsync() => Task.CompletedTask;

        private readonly int _viewModelWordLength = "ViewModel".Length;

        protected async Task PushAsync<TViewModel>(params object[] args)
            where TViewModel : BaseViewModel
        {
            try
            {
                Type viewModelType = typeof(TViewModel);
                string viewModelTypeName = viewModelType.Name;
                string viewTypeName = $"TodoApp.View.{viewModelTypeName.Substring(0, viewModelTypeName.Length - _viewModelWordLength)}Page";
                Type viewType = Type.GetType(viewTypeName);
                var page = Activator.CreateInstance(viewType) as Page;
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
    