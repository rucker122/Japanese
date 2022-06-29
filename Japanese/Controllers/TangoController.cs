using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Japanese.Data;
using Japanese.Models;

namespace Japanese.Controllers
{
    public class TangoController : Controller
    {
        private readonly JapaneseContext _context;

        public TangoController(JapaneseContext context)
        {
            _context = context;
        }

        // GET: Main
        public async Task<IActionResult> Index(string k)
        {
            // get list
            List<VOCABULARY> list = await _context.VOCABULARY.ToListAsync();

            // filter
            if (!string.IsNullOrEmpty(k))
                list = list.Where(o => o.vocabulary.Contains(k) ||
                                       (o.kanji != null && o.kanji.Contains(k)) ||
                                       o.chinese.Contains(k)).ToList();

            ViewBag.Keyword = k;
            return View(list.OrderByDescending(o => o.id));
        }

        // GET: Main/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vOCABULARY = await _context.VOCABULARY
                .FirstOrDefaultAsync(m => m.id == id);
            if (vOCABULARY == null)
            {
                return NotFound();
            }

            return View(vOCABULARY);
        }

        // GET: Main/Create
        public IActionResult Create()
        {

            ViewBag.SpeechList = getSpeechList();

            return View();
        }

        // POST: Main/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VOCABULARY v)
        {
            if (ModelState.IsValid)
            {
                v.create_date = DateTime.Now;
                _context.Add(v);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(v);
        }

        // GET: Main/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vOCABULARY = await _context.VOCABULARY.FindAsync(id);
            if (vOCABULARY == null)
            {
                return NotFound();
            }

            ViewBag.SpeechList = getSpeechList();
            return View(vOCABULARY);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, VOCABULARY v)
        {
            if (id != v.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    v.modify_date = DateTime.Now;
                    _context.Update(v);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VOCABULARYExists(v.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(v);
        }

        // GET: Main/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vOCABULARY = await _context.VOCABULARY
                .FirstOrDefaultAsync(m => m.id == id);
            if (vOCABULARY == null)
            {
                return NotFound();
            }

            return View(vOCABULARY);
        }

        // POST: Main/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vOCABULARY = await _context.VOCABULARY.FindAsync(id);
            _context.VOCABULARY.Remove(vOCABULARY);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Random()
        {
            VOCABULARY v = _context.VOCABULARY.OrderBy(r => Guid.NewGuid()).Take(1).FirstOrDefault();
            SPEECH s = _context.SPEECH.FirstOrDefault(s => s.id == v.speech);


            ViewBag.Speech = s;
            return View(v);
        }




        private bool VOCABULARYExists(int id)
        {
            return _context.VOCABULARY.Any(e => e.id == id);
        }

        protected List<SelectListItem> getSpeechList()
        {
            return _context.SPEECH.Select(o =>
                new SelectListItem
                {
                    Text = o.speech,
                    Value = o.id.ToString(),
                    Selected = false
                }).ToList();
        }
    }
}
