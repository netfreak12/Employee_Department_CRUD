using Microsoft.EntityFrameworkCore;
using MVC_CRUD_APP.Models; // Adjust the namespace according to your project structure

namespace MVC_CRUD_APP.DataContext
{
    public class MVC_CRUD_APP_DbContext: DbContext
    {
        public MVC_CRUD_APP_DbContext(DbContextOptions<MVC_CRUD_APP_DbContext> options) : base(options)
        {
        }
        public DbSet<Models.Employee> Employees { get; set; } // DbSet for Employee model
        public DbSet<Models.Department> Departments { get; set; } // DbSet for Department model
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Additional model configurations can be added here if needed
        }
    }
}
