using Microsoft.EntityFrameworkCore;
using MvcCrudOperation.Models;

namespace MvcCrudOperation.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }
    }
}
