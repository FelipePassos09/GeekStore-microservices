using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GeekShopping.ProductApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "id", "category_name", "description", "immage_url", "name", "price" },
                values: new object[,]
                {
                    { 2L, "T-Shirt", "Description", "https://github.com/FelipePassos09/GeekStore-microservices/blob/main/ShoppingImages/5_100_gamer.jpg", "Camiseta Gamer", 69.9m },
                    { 3L, "T-Shirt", "Description", "https://github.com/FelipePassos09/GeekStore-microservices/blob/main/ShoppingImages/6_spacex.jpg", "Camiseta SpaceX", 69.9m },
                    { 4L, "Action-Figure", "Description", "https://github.com/FelipePassos09/GeekStore-microservices/blob/main/ShoppingImages/4_storm_tropper.jpg", "Storm Trooper", 29.9m },
                    { 5L, "Toy", "Description", "https://github.com/FelipePassos09/GeekStore-microservices/blob/main/ShoppingImages/3_vader.jpg", "Darth Vader Helm", 98.5m },
                    { 6L, "T-Shirt", "Description", "https://github.com/FelipePassos09/GeekStore-microservices/blob/main/ShoppingImages/7_coffee.jpg", "camiseta Feminina Drink Coffe ", 69.9m },
                    { 7L, "Sweatshirt", "Description", "https://github.com/FelipePassos09/GeekStore-microservices/blob/main/ShoppingImages/8_moletom_cobra_kay.jpg", "Moletom Cobra-Kai", 89.9m },
                    { 8L, "Book", "Description", "https://github.com/FelipePassos09/GeekStore-microservices/blob/main/ShoppingImages/9_neil.jpg", "Livro Star Talk - Neil DeFrasse Tyson", 49.9m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 8L);
        }
    }
}
