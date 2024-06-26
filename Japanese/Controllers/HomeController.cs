using Microsoft.AspNetCore.Mvc;
using System.Linq;

using Japanese.Data;

namespace Japanese.Controllers
{
    public class HomeController : Controller
    {
        private readonly JapaneseContext _context;

        public HomeController(JapaneseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.TangoCount = _context.VOCABULARY.Count();
            return View();
        }
    }
}
