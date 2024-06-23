using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Encantos_do_Brasil.Models;

namespace Encantos_do_Brasil.Controllers
{
    public class PontosTuristicosController : Controller
    {
        private readonly AppDbContext _context;

        public PontosTuristicosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PontosTuristicos
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.PontosTuristicos.Include(p => p.Cidade);
            return View(await appDbContext.ToListAsync());
        }

        // GET: PontosTuristicos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PontosTuristicos == null)
            {
                return NotFound();
            }

            var pontoTuristico = await _context.PontosTuristicos
                .Include(p => p.Cidade)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pontoTuristico == null)
            {
                return NotFound();
            }

            return View(pontoTuristico);
        }

        // GET: PontosTuristicos/Create
        public IActionResult Create()
        {
            ViewData["IdCidade"] = new SelectList(_context.Cidades, "Id", "Nome");
            return View();
        }

        // POST: PontosTuristicos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Custo,IdCidade")] PontoTuristico pontoTuristico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pontoTuristico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCidade"] = new SelectList(_context.Cidades, "Id", "Nome", pontoTuristico.IdCidade);
            return View(pontoTuristico);
        }

        // GET: PontosTuristicos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PontosTuristicos == null)
            {
                return NotFound();
            }

            var pontoTuristico = await _context.PontosTuristicos.FindAsync(id);
            if (pontoTuristico == null)
            {
                return NotFound();
            }
            ViewData["IdCidade"] = new SelectList(_context.Cidades, "Id", "Nome", pontoTuristico.IdCidade);
            return View(pontoTuristico);
        }

        // POST: PontosTuristicos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Custo,IdCidade")] PontoTuristico pontoTuristico)
        {
            if (id != pontoTuristico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pontoTuristico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PontoTuristicoExists(pontoTuristico.Id))
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
            ViewData["IdCidade"] = new SelectList(_context.Cidades, "Id", "Nome", pontoTuristico.IdCidade);
            return View(pontoTuristico);
        }

        // GET: PontosTuristicos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PontosTuristicos == null)
            {
                return NotFound();
            }

            var pontoTuristico = await _context.PontosTuristicos
                .Include(p => p.Cidade)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pontoTuristico == null)
            {
                return NotFound();
            }

            return View(pontoTuristico);
        }

        // POST: PontosTuristicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PontosTuristicos == null)
            {
                return Problem("Entity set 'AppDbContext.PontosTuristicos'  is null.");
            }
            var pontoTuristico = await _context.PontosTuristicos.FindAsync(id);
            if (pontoTuristico != null)
            {
                _context.PontosTuristicos.Remove(pontoTuristico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PontoTuristicoExists(int id)
        {
          return _context.PontosTuristicos.Any(e => e.Id == id);
        }
    }
}
