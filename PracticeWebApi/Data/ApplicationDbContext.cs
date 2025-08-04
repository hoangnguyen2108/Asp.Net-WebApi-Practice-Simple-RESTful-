using Microsoft.EntityFrameworkCore;
using PracticeWebApi.Model;

namespace PracticeWebApi.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {
            
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Productid = 1,
                Name = "Name1",
                Price = 10,
                Category = "Category1"
            },new Product
            {
                Productid = 2,
                Name = "Name2",
                Price = 15,
                Category = "Category2"
            });
        }
       
    }
}
