using Japanese.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Japanese.Data;
using Japanese.Models;

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
