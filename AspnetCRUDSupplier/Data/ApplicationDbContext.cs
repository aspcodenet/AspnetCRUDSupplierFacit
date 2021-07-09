using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace AspnetCRUDSupplier.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Supplier> Supplier { get; set; }

    }
}