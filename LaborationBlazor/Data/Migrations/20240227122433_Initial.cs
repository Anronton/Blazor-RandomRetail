using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LaborationBlazor.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImgUrl", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, "A two year old tame eagle", "https://images.pexels.com/photos/16658578/pexels-photo-16658578/free-photo-of-flyg-fagel-djur-orn.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", "Pet Eagle (Apollo)", 499.99m, 1 },
                    { 2, "Surprisingly well sounding beginner guitar", "https://images.pexels.com/photos/1545333/pexels-photo-1545333.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", "Fender Startocaster", 1999.99m, 10 },
                    { 3, "A real fully functional car, not a model", "https://images.pexels.com/photos/35967/mini-cooper-auto-model-vehicle.jpg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", "Mini Cooper Car", 19999.99m, 5 },
                    { 4, "A luxurious kit from Dressman XL, for the man on the larger side", "https://images.pexels.com/photos/2709563/pexels-photo-2709563.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", "Suit set XXL", 999.99m, 15 },
                    { 5, "The beautiful country called Finland, no further explaination is needed", "https://images.pexels.com/photos/2311602/pexels-photo-2311602.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", "Finland", 19999999999999.99m, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
