using Microsoft.EntityFrameworkCore;
using EmployeeAdminPortal.Models.Entities;

namespace EmployeeAdminPortal.data
{
    // Application DBContext class inherits from the DbContext class
    public class ApplicationDbContext : DbContext
    {
        // create a constructor 
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        // properties for the Employees collection
        public DbSet<Employee> Employees { get; set; }
    }
}
