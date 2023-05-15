using Microsoft.EntityFrameworkCore;
using MT.Publisher.Data.Models;

namespace MT.Publisher.Data
{
    public class StoreDbContext: DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options): base(options)
        {
            
        }

        public DbSet<Product> Products => Set<Product>();
    }
}
