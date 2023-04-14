using Microsoft.EntityFrameworkCore;

namespace Test_sql_and_ef_queries_performance.Data
{
	public class AppDbContext : DbContext
	{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
