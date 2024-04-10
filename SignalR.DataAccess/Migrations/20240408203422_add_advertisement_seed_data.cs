using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.DataAccess.Migrations
{
    public partial class add_advertisement_seed_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Advertisements",
                columns: new[] { "Id", "Description1", "Description2", "Description3", "Title1", "Title2", "Title3" },
                values: new object[] { 1, "İtalya'nın eşsiz makarna lezzetlerini sizler için Türk mutfağının geleneksel ezgisiyle birleştirip pestodan parmesana, kremadan domates sosuna kadar birçok farklı tatla sunmanın mutluluğunu yaşıyoruz.", "Hem Asya hem de Avrupa'nın en lezzetli sokak ve kafe yemeklerini sizlerin hizmetine sunduk. Tatlılar, içecekler, baharatlar ve eşsiz hamur ürünleriyle çok keyifli bir öğün geçirmeye ne dersiniz ?", "Sizin istediğiniz ölçüde ğişirilen, avokado, patlıcan, kabask ve diper soslarla harmanlanmış, eşsiz patates kızartması eşliğinde tamamen sağlıklı ve doğal bir hamburger yemeye hazır mısınız.", "Lezzetli Makarnalar", "Uzak Doğu Mutfağı", "Eşsiz Hamburger" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
