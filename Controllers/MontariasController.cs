using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using trabalho_rodeio.Models;

namespace trabalho_rodeio.Controllers
{
    public class MontariasController : Controller
    {
        private readonly Contexto _context;

        public MontariasController(Contexto context)
        {
            _context = context;
        }

        // GET: Montarias
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Montarias.Include(m => m.Peao).Include(m => m.Touro);
            return View(await contexto.ToListAsync());
        }

        // GET: Montarias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Montarias == null)
            {
                return NotFound();
            }

            var montaria = await _context.Montarias
                .Include(m => m.Peao)
                .Include(m => m.Touro)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (montaria == null)
            {
                return NotFound();
            }

            return View(montaria);
        }

        // GET: Montarias/Create
        public IActionResult Create()
        {
            ViewData["PeaoId"] = new SelectList(_context.Peoes, "Id", "Nome");
            ViewData["TouroId"] = new SelectList(_context.Touros, "Id", "Nome");
            return View();
        }

        // POST: Montarias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Data,PeaoId,TouroId")] Montaria montaria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(montaria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PeaoId"] = new SelectList(_context.Peoes, "Id", "Nome", montaria.PeaoId);
            ViewData["TouroId"] = new SelectList(_context.Touros, "Id", "Nome", montaria.TouroId);
            return View(montaria);
        }

        // GET: Montarias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Montarias == null)
            {
                return NotFound();
            }

            var montaria = await _context.Montarias.FindAsync(id);
            if (montaria == null)
            {
                return NotFound();
            }
            ViewData["PeaoId"] = new SelectList(_context.Peoes, "Id", "Nome", montaria.PeaoId);
            ViewData["TouroId"] = new SelectList(_context.Touros, "Id", "Nome", montaria.TouroId);
            return View(montaria);
        }

        // POST: Montarias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Data,PeaoId,TouroId")] Montaria montaria)
        {
            if (id != montaria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(montaria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MontariaExists(montaria.Id))
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
            ViewData["PeaoId"] = new SelectList(_context.Peoes, "Id", "Nome", montaria.PeaoId);
            ViewData["TouroId"] = new SelectList(_context.Touros, "Id", "Nome", montaria.TouroId);
            return View(montaria);
        }

        // GET: Montarias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Montarias == null)
            {
                return NotFound();
            }

            var montaria = await _context.Montarias
                .Include(m => m.Peao)
                .Include(m => m.Touro)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (montaria == null)
            {
                return NotFound();
            }

            return View(montaria);
        }

        // POST: Montarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Montarias == null)
            {
                return Problem("Entity set 'Contexto.Montarias'  is null.");
            }
            var montaria = await _context.Montarias.FindAsync(id);
            if (montaria != null)
            {
                _context.Montarias.Remove(montaria);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MontariaExists(int id)
        {
          return _context.Montarias.Any(e => e.Id == id);
        }
    }
}
