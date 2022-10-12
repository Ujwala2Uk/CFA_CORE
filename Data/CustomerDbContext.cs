using CFA_CORE.Models;
using Microsoft.EntityFrameworkCore;

namespace CFA_CORE.Data
{
    public class CustomerDbContext:DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options):base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }

    }
}
