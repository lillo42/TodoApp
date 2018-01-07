using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using TodoApp.Entity;
using Xamarin.Forms;

namespace TodoApp.ViewModel
{
    public sealed class TodoListViewModel : BaseViewModel
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

        public ICommand SelectItem { get; }

        public TodoListViewModel()
        {
            SelectItem = new Command<TodoItem>(SelectItemAcitonAsync);
        }

        private async void SelectItemAcitonAsync(TodoItem todo)
        {
            await PushAsync<TodoItemViewModel>(todo);
        }
    }
}
