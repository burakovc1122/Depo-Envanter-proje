using Microsoft.AspNetCore.Mvc;

namespace projebeycelik.Controllers
{
    public class LokasyonController : Controller
    {
        public IActionResult Index()
        {
            // Tüm lokasyon bilgileri
            var lokasyonlar = new List<LokasyonViewModel>
            {
                new LokasyonViewModel
                {
                    Id = "BGO",
                    Isim = "BGO",
                    Adres = "Işıktepe OSB. Kahverengi Caddesi No:13 Nilüfer/Bursa",
                    Telefon = "+90 224 270 06 00",
                    Sorumlu = "Burak Öveç",
                    Email = "burakovec@beycelikgestamp.com.tr",
                    Resim = "resim/bgo.jpg"
                },
                new LokasyonViewModel
                {
                    Id = "BGW",
                    Isim = "BGW",
                    Adres = "Işıktepe OSB, 75. Yıl Blv. No:8 D:10, 16140 Nilüfer/Bursa",
                    Telefon = "+90 224 280 52 00",
                    Sorumlu = "Burak Öveç",
                    Email = "burakovec@beycelikgestamp.com.tr",
                    Resim = "resim/bgw.jpg"
                },
                new LokasyonViewModel
                {
                    Id = "BGD",
                    Isim = "BGD",
                    Adres = "Demirtaş Dumlupınar OSB, Kardelen Sk. No:12, 16245 Osmangazi/Bursa",
                    Telefon = "+90 224 294 83 00",
                    Sorumlu = "Burak Öveç",
                    Email = "burakovec@beycelikgestamp.com.tr",
                    Resim = "resim/bgw.jpg"
                },
                new LokasyonViewModel
                {
                    Id = "BGC",
                    Isim = "BGC",
                    Adres = "Tosb Otomotiv Osb, Mahallesi, 1. Cd. No:5, 41420 Çayırova/Kocaeli",
                    Telefon = "+90 262 673 30 00",
                    Sorumlu = "Burak Öveç",
                    Email = "burakovec@beycelikgestamp.com.tr",
                    Resim = "resim/bgw.jpg"
                },
                new LokasyonViewModel
                {
                    Id = "CEF",
                    Isim = "CEF",
                    Adres = "Işıktepe OSB, Kırmızı Cd. No:1, 16140 Nilüfer/Bursa",
                    Telefon = "+90 262 673 30 00",
                    Sorumlu = "Burak Öveç",
                    Email = "burakovec@beycelikgestamp.com.tr",
                    Resim = "resim/bgw.jpg"
                },
                new LokasyonViewModel
                {
                    Id = "BGY",
                    Isim = "BGY",
                    Adres = "Sepetlipınar, Arpalık Cd. No:53, 41275 Başiskele/Kocaeli",
                    Telefon = "-",
                    Sorumlu = "Burak Öveç",
                    Email = "burakovec@beycelikgestamp.com.tr",
                    Resim = "resim/bgw.jpg"
                },
                new LokasyonViewModel
                {
                    Id = "TEKNOSAB-BGT",
                    Isim = "TEKNOSAB-BGT",
                    Adres = "Taşpınar, 16700 Karacabey/Bursa",
                    Telefon = "-",
                    Sorumlu = "Burak Öveç",
                    Email = "burakovec@beycelikgestamp.com.tr",
                    Resim = "resim/bgw.jpg"
                },
                new LokasyonViewModel
                {
                    Id = "BGR",
                    Isim = "BGR",
                    Adres = "Dârmănești 117360, Romanya",
                    Telefon = "+40 248 606 216",
                    Sorumlu = "Burak Öveç",
                    Email = "burakovec@beycelikgestamp.com.tr",
                    Resim = "resim/bgw.jpg"
                }
            };

            return View(lokasyonlar);
        }
    }

    public class LokasyonViewModel
    {
        public string? Id { get; set; }
        public string? Isim { get; set; }
        public string? Adres { get; set; }
        public string? Telefon { get; set; }
        public string? Sorumlu { get; set; }
        public string? Email { get; set; }
        public string? Resim { get; set; }
    }
}
