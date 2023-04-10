using Microsoft.EntityFrameworkCore;

namespace Product_API.Model
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
    }
}
