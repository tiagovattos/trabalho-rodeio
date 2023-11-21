using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using trabalho_rodeio.Models;

namespace trabalho_rodeio.Controllers
{
    [Authorize]
    public class PeoesController : Controller
    {
        private readonly Contexto _context;

        public PeoesController(Contexto context)
        {
            _context = context;
        }

        public IActionResult GerarPeoes()
        {

            var todosPeoes = _context.Peoes.ToList();
            _context.Peoes.RemoveRange(todosPeoes);
            _context.SaveChanges();

            Random random = new Random();
            string[] vnome = { "João", "Maria", "Pedro", "Ana", "Carlos", "Laura", "Fernando", "Leticia", "Gabriel", "Isabel" };
            string[] vsobrenome = { "Silva", "Oliveira", "Pereira", "Santos", "Costa", "Lima", "Martins", "Cruz", "Melo", "Almeida" };

            for (int i = 0; i < 20; i++)
            {
                Peao peao = new Peao();

                string nomeCompleto = vnome[random.Next(vnome.Length)] + " " + vsobrenome[random.Next(vsobrenome.Length)];
                peao.Nome = nomeCompleto;

                DateTime dataNascimento = new DateTime(1950, 1, 1);
                int diasAleatorios = random.Next(0, 17000);
                dataNascimento = dataNascimento.AddDays(diasAleatorios);

                peao.DataNascimento = dataNascimento;

                peao.QuantidadeMontarias = random.Next(0, 100);

                _context.Peoes.Add(peao);
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Peoes");
        }

        // GET: Peoes
        [AllowAnonymous]
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["NameSortParam"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            var peoes = _context.Peoes.AsQueryable();

            switch (sortOrder)
            {
                case "name_desc":
                    peoes = peoes.OrderByDescending(p => p.Nome);
                    break;
                default:
                    peoes = peoes.OrderBy(p => p.Nome);
                    break;
            }

            return View(await peoes.ToListAsync());
        }


        // GET: Peoes/Details/5
        [AllowAnonymous]
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
