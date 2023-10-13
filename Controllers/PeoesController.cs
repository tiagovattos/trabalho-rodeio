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
    public class PeoesController : Controller
    {
        private readonly Contexto _context;

        public PeoesController(Contexto context)
        {
            _context = context;
        }

        // GET: Peoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Peoes.ToListAsync());
        }

        // GET: Peoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Peoes == null)
            {
                return NotFound();
            }

            var peao = await _context.Peoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (peao == null)
            {
                return NotFound();
            }

            return View(peao);
        }

        // GET: Peoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Peoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,DataNascimento,QuantidadeMontarias")] Peao peao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(peao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(peao);
        }

        // GET: Peoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Peoes == null)
            {
                return NotFound();
            }

            var peao = await _context.Peoes.FindAsync(id);
            if (peao == null)
            {
                return NotFound();
            }
            return View(peao);
        }

        // POST: Peoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,DataNascimento,QuantidadeMontarias")] Peao peao)
        {
            if (id != peao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(peao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeaoExists(peao.Id))
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
            return View(peao);
        }

        // GET: Peoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Peoes == null)
            {
                return NotFound();
            }

            var peao = await _context.Peoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (peao == null)
            {
                return NotFound();
            }

            return View(peao);
        }

        // POST: Peoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Peoes == null)
            {
                return Problem("Entity set 'Contexto.Peoes'  is null.");
            }
            var peao = await _context.Peoes.FindAsync(id);
            if (peao != null)
            {
                _context.Peoes.Remove(peao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeaoExists(int id)
        {
          return _context.Peoes.Any(e => e.Id == id);
        }
    }
}
