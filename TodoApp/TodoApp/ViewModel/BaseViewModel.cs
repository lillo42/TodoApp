using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TodoApp.Data;

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
    }
}
