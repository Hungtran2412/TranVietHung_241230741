using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TranVietHung_241230741.Models;

namespace TranVietHung_241230741.Controllers
{
    public class HomeController : Controller
    {
        private readonly QlnhaSachContext _context;
        public HomeController(QlnhaSachContext context) { _context = context; }
        public IActionResult Index()
        {
            ViewBag.TheLoaiList = _context.TheLoais.ToList();
            var dsSach = _context.Saches.Where(s => s.Gia != null && s.Gia >= 100).ToList();
            return View(dsSach);
        }

        public IActionResult GetSachByTheloai(int id)
        {
            var dsSach = _context.Saches.Where(s => s.MaTl == id).ToList();
            return PartialView("_SachListPartial", dsSach);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
