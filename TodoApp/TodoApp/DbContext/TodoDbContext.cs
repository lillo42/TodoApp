using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Models;

namespace TodoApp.DbContext
{
    public class TodoDbContext
    {
        private readonly SQLiteAsyncConnection _database;

        public TodoDbContext(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<TodoItem>().Wait();
        }

        public Task<List<TodoItem>> Getsync() => _database.Table<TodoItem>().ToListAsync();

        public Task<List<TodoItem>> GetNotDoneAsync() => _database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [IsDone] = 0");

        public Task<TodoItem> GetAsync(int id) => _database.Table<TodoItem>().Where(x => x.Id == id).FirstOrDefaultAsync();

        public Task<int> DeleteAsync(TodoItem todo) => _database.DeleteAsync(todo);

        public Task<int> SaveAsync(TodoItem todo)
        {
            if (todo.Id != 0)
                return _database.UpdateAsync(todo);
            else
                return _database.InsertAsync(todo);
        }
    }
}
