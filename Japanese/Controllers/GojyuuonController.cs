using Japanese.Data;
using Japanese.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Japanese.Controllers
{
    public class GojyuuonController : Controller
    {
        private readonly JapaneseContext _context;

        public GojyuuonController(JapaneseContext context)
        {
            _context = context;
        }

        // GET: Main
        public async Task<IActionResult> Index()
        {
            // get list
            List<SYLLABARIES> list = await _context.SYLLABARIES.ToListAsync();

            return View(list);
        }
    }
}
