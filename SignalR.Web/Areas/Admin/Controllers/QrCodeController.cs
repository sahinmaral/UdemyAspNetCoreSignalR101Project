using Microsoft.AspNetCore.Mvc;
using QRCoder;

namespace SignalR.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QrCodeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Index(string value)
        {
            QRCodeData qrCodeData;
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                qrCodeData = qrGenerator.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);
            }
            
            var imgType = Base64QRCode.ImageType.Png;
            var qrCode = new Base64QRCode(qrCodeData);
            string qrCodeImageAsBase64 = qrCode.GetGraphic(20, SixLabors.ImageSharp.Color.Black, 
                SixLabors.ImageSharp.Color.White, true, imgType);
            
            ViewBag.QrCodeImage = qrCodeImageAsBase64;
            ViewBag.ImageType = imgType.ToString().ToLower();

            return View();
        }
    }
}