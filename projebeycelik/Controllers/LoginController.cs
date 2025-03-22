using Microsoft.AspNetCore.Mvc;
using projebeycelik.Models;

namespace projebeycelik.Controllers
{
    public class LoginController : Controller
    {
        // Giriş doğrulaması yapan metod
        [HttpPost]
        public IActionResult Validate(string username, string password)
        {
            if (username == "admin" && password == "admin")  // Burada admin/admin olarak belirledik
            {
                return RedirectToAction("Index", "Anasayfa");  // Doğru girişte Depoenvanter Index'e yönlendir
            }

            // Yanlış giriş yapıldığında hata mesajı ekleyin
            ViewBag.ErrorMessage = "Kullanıcı adı veya şifre yanlış.";
            return View("Index");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
