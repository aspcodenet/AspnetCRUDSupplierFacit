using Microsoft.EntityFrameworkCore;

namespace AspnetCRUDSupplier.Data
{
    public class DataInitializer
    {
        public static void SeedData(ApplicationDbContext dbContext)
        {
            dbContext.Database.Migrate();
        }

    }
}