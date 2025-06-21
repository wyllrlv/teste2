// Controllers/HomeController.cs
using Microsoft.AspNetCore.Mvc;
using ex_full.Models;
using System.Diagnostics;

namespace ex_full.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Redireciona automaticamente para o treino 1
            return RedirectToAction("Detalhes", "Treino", new { id = 1 });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}