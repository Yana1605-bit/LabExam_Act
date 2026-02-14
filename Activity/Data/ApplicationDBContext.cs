using Activity.Model.Domain;
using Activity.Model.POS;
using Microsoft.EntityFrameworkCore;

namespace Activity.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextoptions) : base(dbContextoptions)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
