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
    public class TextosCidadesController : Controller
    {
        private readonly AppDbContext _context;

        public TextosCidadesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TextosCidades
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.TextoCidades.Include(t => t.Cidade);
            return View(await appDbContext.ToListAsync());
        }

        // GET: TextosCidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TextoCidades == null)
            {
                return NotFound();
            }

            var textoCidade = await _context.TextoCidades
                .Include(t => t.Cidade)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (textoCidade == null)
            {
                return NotFound();
            }

            return View(textoCidade);
        }

        // GET: TextosCidades/Create
        public IActionResult Create()
        {
            ViewData["IdCidade"] = new SelectList(_context.Cidades, "Id", "Nome");
            return View();
        }

        // POST: TextosCidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TituloTexto,Texto,TipoTexto,IdCidade")] TextoCidade textoCidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(textoCidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCidade"] = new SelectList(_context.Cidades, "Id", "Nome", textoCidade.IdCidade);
            return View(textoCidade);
        }

        // GET: TextosCidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TextoCidades == null)
            {
                return NotFound();
            }

            var textoCidade = await _context.TextoCidades.FindAsync(id);
            if (textoCidade == null)
            {
                return NotFound();
            }
            ViewData["IdCidade"] = new SelectList(_context.Cidades, "Id", "Nome", textoCidade.IdCidade);
            return View(textoCidade);
        }

        // POST: TextosCidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TituloTexto,Texto,TipoTexto,IdCidade")] TextoCidade textoCidade)
        {
            if (id != textoCidade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(textoCidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TextoCidadeExists(textoCidade.Id))
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
            ViewData["IdCidade"] = new SelectList(_context.Cidades, "Id", "Nome", textoCidade.IdCidade);
            return View(textoCidade);
        }

        // GET: TextosCidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TextoCidades == null)
            {
                return NotFound();
            }

            var textoCidade = await _context.TextoCidades
                .Include(t => t.Cidade)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (textoCidade == null)
            {
                return NotFound();
            }

            return View(textoCidade);
        }

        // POST: TextosCidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TextoCidades == null)
            {
                return Problem("Entity set 'AppDbContext.TextoCidades'  is null.");
            }
            var textoCidade = await _context.TextoCidades.FindAsync(id);
            if (textoCidade != null)
            {
                _context.TextoCidades.Remove(textoCidade);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TextoCidadeExists(int id)
        {
          return _context.TextoCidades.Any(e => e.Id == id);
        }
    }
}
