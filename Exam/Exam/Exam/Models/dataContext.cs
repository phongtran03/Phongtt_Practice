using Microsoft.EntityFrameworkCore;

namespace Exam.Models
{
    public class dataContext : DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public dataContext(DbContextOptions options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryID="SK1",
                CategoryName="Mobile Phone",
                Description="The Phone for every one",
                Picture="image1.jpg"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryID = "SK2",
                CategoryName = "Book",
                Description = "Book for Student",
                Picture = "image2.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductID="QW1",
                ProductName="Iphone 15",
                SupplierID="HJ2",
                CategoryID="SK1",
                QuantityPerUnit=1,
                UnitPrice=23.44,
                UnitslnStock=0.13,
                UnnitsOnOrder=3,
                ReorderLevel=1,
                Discontinued=5.6

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductID = "QW2",
                ProductName = "JAVA book",
                SupplierID = "HJ3",
                CategoryID = "SK2",
                QuantityPerUnit = 2,
                UnitPrice = 20.44,
                UnitslnStock = 0.13,
                UnnitsOnOrder = 3,
                ReorderLevel = 1,
                Discontinued = 5.6

            });
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
