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
    public class TourosController : Controller
    {
        private readonly Contexto _context;

        public TourosController(Contexto context)
        {
            _context = context;
        }

        // GET: Touros
        public async Task<IActionResult> Index()
        {
              return View(await _context.Touros.ToListAsync());
        }

        // GET: Touros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Touros == null)
            {
                return NotFound();
            }

            var touro = await _context.Touros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (touro == null)
            {
                return NotFound();
            }

            return View(touro);
        }

        // GET: Touros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Touros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Idade,QuantidadeMontarias")] Touro touro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(touro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(touro);
        }

        // GET: Touros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Touros == null)
            {
                return NotFound();
            }

            var touro = await _context.Touros.FindAsync(id);
            if (touro == null)
            {
                return NotFound();
            }
            return View(touro);
        }

        // POST: Touros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Idade,QuantidadeMontarias")] Touro touro)
        {
            if (id != touro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(touro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TouroExists(touro.Id))
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
            return View(touro);
        }

        // GET: Touros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Touros == null)
            {
                return NotFound();
            }

            var touro = await _context.Touros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (touro == null)
            {
                return NotFound();
            }

            return View(touro);
        }

        // POST: Touros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Touros == null)
            {
                return Problem("Entity set 'Contexto.Touros'  is null.");
            }
            var touro = await _context.Touros.FindAsync(id);
            if (touro != null)
            {
                _context.Touros.Remove(touro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TouroExists(int id)
        {
          return _context.Touros.Any(e => e.Id == id);
        }
    }
}
