using Microsoft.EntityFrameworkCore;
using webapi.Models;
namespace webapi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)  : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerJob> CustomerJob { get; set; }
        public DbSet<CustomerRelation> CustomerRelation { get; set; }


    }
}