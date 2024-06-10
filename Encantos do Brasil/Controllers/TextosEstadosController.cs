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
    public class TextosEstadosController : Controller
    {
        private readonly AppDbContext _context;

        public TextosEstadosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TextosEstados
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.TextoEstados.Include(t => t.Cidade);
            return View(await appDbContext.ToListAsync());
        }

        // GET: TextosEstados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TextoEstados == null)
            {
                return NotFound();
            }

            var textoEstado = await _context.TextoEstados
                .Include(t => t.Cidade)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (textoEstado == null)
            {
                return NotFound();
            }

            return View(textoEstado);
        }

        // GET: TextosEstados/Create
        public IActionResult Create()
        {
            ViewData["IdEstado"] = new SelectList(_context.Estados, "Id", "Nome");
            return View();
        }

        // POST: TextosEstados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TituloTexto,Texto,TipoTexto,IdEstado")] TextoEstado textoEstado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(textoEstado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstado"] = new SelectList(_context.Estados, "Id", "Nome", textoEstado.IdEstado);
            return View(textoEstado);
        }

        // GET: TextosEstados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TextoEstados == null)
            {
                return NotFound();
            }

            var textoEstado = await _context.TextoEstados.FindAsync(id);
            if (textoEstado == null)
            {
                return NotFound();
            }
            ViewData["IdEstado"] = new SelectList(_context.Estados, "Id", "Nome", textoEstado.IdEstado);
            return View(textoEstado);
        }

        // POST: TextosEstados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TituloTexto,Texto,TipoTexto,IdEstado")] TextoEstado textoEstado)
        {
            if (id != textoEstado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(textoEstado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TextoEstadoExists(textoEstado.Id))
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
            ViewData["IdEstado"] = new SelectList(_context.Estados, "Id", "Nome", textoEstado.IdEstado);
            return View(textoEstado);
        }

        // GET: TextosEstados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TextoEstados == null)
            {
                return NotFound();
            }

            var textoEstado = await _context.TextoEstados
                .Include(t => t.Cidade)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (textoEstado == null)
            {
                return NotFound();
            }

            return View(textoEstado);
        }

        // POST: TextosEstados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TextoEstados == null)
            {
                return Problem("Entity set 'AppDbContext.TextoEstados'  is null.");
            }
            var textoEstado = await _context.TextoEstados.FindAsync(id);
            if (textoEstado != null)
            {
                _context.TextoEstados.Remove(textoEstado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TextoEstadoExists(int id)
        {
          return _context.TextoEstados.Any(e => e.Id == id);
        }
    }
}
