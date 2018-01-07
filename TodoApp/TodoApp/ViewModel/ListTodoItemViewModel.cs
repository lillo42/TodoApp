using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TodoApp.Entity;

namespace TodoApp.ViewModel
{
    public sealed class ListTodoItemViewModel : BaseViewModel
    {
        private ObservableCollection<TodoItem> _todoItens;

        public ObservableCollection<TodoItem> TodoItens
        {
            get => _todoItens;
            set => SetProperty(ref _todoItens, value);
        }

        public override Task LoadAsync()
        {
            TodoItens = new ObservableCollection<TodoItem>(DbContext.TodoItens);
            return base.LoadAsync();
        }
    }
}
