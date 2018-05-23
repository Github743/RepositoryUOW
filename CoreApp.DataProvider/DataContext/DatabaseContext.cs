using CoreApp.Models.Models;
using System.Data.Entity;

namespace CoreApp.DataProvider.DataContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=dbConnection")
        {

        }
        public DbSet<Employee> Employee { get; set; }
    }
}
