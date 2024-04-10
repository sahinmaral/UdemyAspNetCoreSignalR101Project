using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.DataAccess.Migrations
{
    public partial class add_discount_of_day_seed_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DiscountOfDays",
                columns: new[] { "Id", "Amount", "Description", "ImageUrl", "Title" },
                values: new object[] { 1, 20, "Perşembe günleri için hamburger kategorisinde indirim", "~/feane/images/o1.jpg", "Lezzetli Perşembeler" });

            migrationBuilder.InsertData(
                table: "DiscountOfDays",
                columns: new[] { "Id", "Amount", "Description", "ImageUrl", "Title" },
                values: new object[] { 2, 15, "Belirlenen günlerde pizza kategorisinde indirim", "~/feane/images/o2.jpg", "Pizza Günleri  " });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DiscountOfDays",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DiscountOfDays",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
