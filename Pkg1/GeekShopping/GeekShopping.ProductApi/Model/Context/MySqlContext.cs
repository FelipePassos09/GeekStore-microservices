using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductApi.Model.Context;

public class MySqlContext : DbContext
{
    public MySqlContext() { }
    public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(new Product
        {

            id = 2,
            Name = "Camiseta Gamer",
            Price = 69.9m,
            Description = "Description",
            ImmageUrl = "https://github.com/FelipePassos09/GeekStore-microservices/blob/main/ShoppingImages/5_100_gamer.jpg",
            CategoryName = "T-Shirt",
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {

            id = 3,
            Name = "Camiseta SpaceX",
            Price = 69.9m,
            Description = "Description",
            ImmageUrl = "https://github.com/FelipePassos09/GeekStore-microservices/blob/main/ShoppingImages/6_spacex.jpg",
            CategoryName = "T-Shirt",
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {

            id = 4,
            Name = "Storm Trooper",
            Price = 29.9m,
            Description = "Description",
            ImmageUrl = "https://github.com/FelipePassos09/GeekStore-microservices/blob/main/ShoppingImages/4_storm_tropper.jpg",
            CategoryName = "Action-Figure",
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {

            id = 5,
            Name = "Darth Vader Helm",
            Price = 98.5m,
            Description = "Description",
            ImmageUrl = "https://github.com/FelipePassos09/GeekStore-microservices/blob/main/ShoppingImages/3_vader.jpg",
            CategoryName = "Toy",
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {

            id = 6,
            Name = "camiseta Feminina Drink Coffe ",
            Price = 69.9m,
            Description = "Description",
            ImmageUrl = "https://github.com/FelipePassos09/GeekStore-microservices/blob/main/ShoppingImages/7_coffee.jpg",
            CategoryName = "T-Shirt",
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {

            id = 7,
            Name = "Moletom Cobra-Kai",
            Price = 89.9m,
            Description = "Description",
            ImmageUrl = "https://github.com/FelipePassos09/GeekStore-microservices/blob/main/ShoppingImages/8_moletom_cobra_kay.jpg",
            CategoryName = "Sweatshirt",
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {

            id = 8,
            Name = "Livro Star Talk - Neil DeFrasse Tyson",
            Price = 49.9m,
            Description = "Description",
            ImmageUrl = "https://github.com/FelipePassos09/GeekStore-microservices/blob/main/ShoppingImages/9_neil.jpg",
            CategoryName = "Book",
        });
    }
}
