using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Models;

namespace ToDoListAPI.Data
{
    public class ToDoListContext : DbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=.;Database=ToDoDB;Trusted_connection=true;TrustServerCertificate=Yes");
        }

    }
}
