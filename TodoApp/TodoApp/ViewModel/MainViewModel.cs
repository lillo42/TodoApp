using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using TodoApp.Models;
using Xamarin.Forms;

namespace TodoApp.ViewModel
{
    public sealed  class MainViewModel : BaseViewModel
    {
        private ObservableCollection<TodoItem> _todoItens;

        public ObservableCollection<TodoItem> TodoItens
        {
            get => _todoItens;
            set => SetProperty(ref _todoItens, value);
        }


        public ICommand NewTodoItemCommand { get; }
        public ICommand EditTodoItemCommand { get; }

        public MainViewModel()
        {
            Title = "Todo";

            NewTodoItemCommand = new Command(ExecuteNewTodoItemCommand);
            EditTodoItemCommand = new Command<TodoItem>(ExecuteEditTodoItemCommand);
        }

        private async void ExecuteNewTodoItemCommand()
        {
            await PushAsync<TodoItemViewModel>(new TodoItem());
        }

        private async void ExecuteEditTodoItemCommand(TodoItem item)
        {
            await PushAsync<TodoItemViewModel>(item);
        }

        public override async Task LoadAsync() => TodoItens = new ObservableCollection<TodoItem>(await Database.Getsync());
    }
}
