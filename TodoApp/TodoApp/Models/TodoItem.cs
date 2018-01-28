using SQLite;

namespace TodoApp.Models
{
    public class TodoItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public bool IsDone { get; set; }

        public void Deconstruct(out string name, out string notes, out bool isDone)
        {
            name = Name;
            notes = Notes;
            isDone = IsDone;
        }
    }
}
