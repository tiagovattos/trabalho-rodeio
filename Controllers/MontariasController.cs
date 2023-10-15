using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            var montarias = await _context.Montarias.Include(m => m.Peao).Include(m => m.Touro).ToListAsync();
            return View(montarias);
        }

        // GET: Montarias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var montaria = await _context.Montarias.Include(m => m.Peao).Include(m => m.Touro)
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
            return View();
        }

        // POST: Montarias/Create
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
            return View(montaria);
        }

        // GET: Montarias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var montaria = await _context.Montarias.FindAsync(id);
            if (montaria == null)
            {
                return NotFound();
            }
            return View(montaria);
        }

        // POST: Montarias/Edit/5
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
            return View(montaria);
        }

        // GET: Montarias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var montaria = await _context.Montarias
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
            var montaria = await _context.Montarias.FindAsync(id);
            if (montaria != null)
            {
                _context.Montarias.Remove(montaria);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool MontariaExists(int id)
        {
            return _context.Montarias.Any(e => e.Id == id);
        }
    }
}
