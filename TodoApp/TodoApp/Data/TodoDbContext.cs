using Microsoft.EntityFrameworkCore;
using TodoApp.Entity;
using TodoApp.Interface;
using Xamarin.Forms;

namespace TodoApp.Data
{
    public sealed class TodoDbContext : DbContext
    {
        public DbSet<TodoItem> TodoItens { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(DependencyService.Get<IFileHelper>().GetLocalFilePath("TodoSQLite.db3"));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TodoItem>()
                    .ToTable(nameof(TodoItem))
                    .HasKey(x => x.Id);

            modelBuilder.Entity<TodoItem>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
