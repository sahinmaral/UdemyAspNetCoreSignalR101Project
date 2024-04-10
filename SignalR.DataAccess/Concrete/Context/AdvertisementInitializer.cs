using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SignalR.Entity.Concrete;

namespace SignalR.DataAccess.Concrete.Context;

public class AdvertisementInitializer
{
    public static void Initialize(EntityTypeBuilder<Advertisement> advertisementBuilder)
    {
        var advertisement = new Advertisement
        {
            Id = 1,
            Title1 = "Lezzetli Makarnalar",
            Title2 = "Uzak Doğu Mutfağı",
            Title3 = "Eşsiz Hamburger",
            Description1 =
                "İtalya'nın eşsiz makarna lezzetlerini sizler için Türk mutfağının geleneksel ezgisiyle birleştirip pestodan parmesana, kremadan domates sosuna kadar birçok farklı tatla sunmanın mutluluğunu yaşıyoruz.",
            Description2 =
                "Hem Asya hem de Avrupa'nın en lezzetli sokak ve kafe yemeklerini sizlerin hizmetine sunduk. Tatlılar, içecekler, baharatlar ve eşsiz hamur ürünleriyle çok keyifli bir öğün geçirmeye ne dersiniz ?",
            Description3 =
                "Sizin istediğiniz ölçüde ğişirilen, avokado, patlıcan, kabask ve diper soslarla harmanlanmış, eşsiz patates kızartması eşliğinde tamamen sağlıklı ve doğal bir hamburger yemeye hazır mısınız.",
        };

        advertisementBuilder.HasData(advertisement);
    }
}