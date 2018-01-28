using System;
using System.Threading.Tasks;
using System.Windows.Input;
using TodoApp.Interface;
using TodoApp.Models;
using Xamarin.Forms;

namespace TodoApp.ViewModel
{
    public sealed class TodoItemViewModel : BaseViewModel
    {
        private readonly TodoItem _todoItem;

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _notes;
        public string Notes
        {
            get => _notes;
            set => SetProperty(ref _notes, value);
        }

        private bool _isDone;
        public bool IsDone
        {
            get => _isDone;
            set => SetProperty(ref _isDone, value);
        }

        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand SpeakCommand { get; }

        public TodoItemViewModel(TodoItem todoItem)
        {
            Title = "Add/Edit ToDo item";
            _todoItem = todoItem ?? throw new ArgumentNullException(nameof(todoItem));

            SaveCommand = new Command(ExecuteSaveCommand);
            DeleteCommand = new Command(ExecuteDeleteCommand);
            CancelCommand = new Command(ExecuteCancelCommand);
            SpeakCommand = new Command(ExecuteSpeakCommand);
        }


        private async void ExecuteSaveCommand()
        {
            _todoItem.Name = Name;
            _todoItem.Notes = Notes;
            _todoItem.IsDone = IsDone;

            await Database.SaveAsync(_todoItem);
            ExecuteCancelCommand();
        }

        private async void ExecuteDeleteCommand()
        {
            await Database.DeleteAsync(_todoItem);
            ExecuteCancelCommand();
        }

        private async void ExecuteCancelCommand()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }

        private async void ExecuteSpeakCommand()
        {
            DependencyService.Get<ITextToSpeech>().Speak($"{_todoItem.Name} {_todoItem.Notes}");
        }

        public override Task LoadAsync()
        {
            (Name, Notes, IsDone) = _todoItem;
            return base.LoadAsync();
        }
    }
}
