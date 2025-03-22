using Microsoft.AspNetCore.Mvc;

namespace projebeycelik.Controllers
{
    public class AnasayfaController : Controller
    {
        public IActionResult Index()
        {
            return View(); // Ana sayfa görüntüleniyor
        }

        // Çıkış fonksiyonu
        public IActionResult Logout()
        {
            // Burada oturumu sonlandırma işlemi yapılabilir (örneğin session temizleme)
            return RedirectToAction("Index", "Login"); // Giriş sayfasına yönlendir
        }
    }
}
