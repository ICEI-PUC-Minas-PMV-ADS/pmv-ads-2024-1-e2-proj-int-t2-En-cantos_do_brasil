using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Encantos_do_Brasil.Models;
using Microsoft.AspNetCore.Authorization;

namespace Encantos_do_Brasil.Controllers
{
    [Authorize]
    public class CidadesController : Controller
    {
        private readonly AppDbContext _context;
        private object cidade;

        public CidadesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Cidades
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Cidades.Include(c => c.Estado).Include(i=> i.ImagensCidades);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Cidades/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cidades == null)
            {
                return NotFound();
            }

            var cidade = await _context.Cidades
                .Include(c => c.Estado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cidade == null)
            {
                return NotFound();
            }

            return View(cidade);
        }

        // GET: Cidades/Create
        public IActionResult Create()
        {
            ViewData["IdEstado"] = new SelectList(_context.Estados, "Id", "Nome");
            return View();
        }

        // POST: Cidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,IdEstado,Preferencia")] Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstado"] = new SelectList(_context.Estados, "Id", "Nome", cidade.IdEstado);
            return View(cidade);
        }

        // GET: Cidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cidades == null)
            {
                return NotFound();
            }

            var cidade = await _context.Cidades.FindAsync(id);
            if (cidade == null)
            {
                return NotFound();
            }
            ViewData["IdEstado"] = new SelectList(_context.Estados, "Id", "Nome", cidade.IdEstado);
            return View(cidade);
        }

        // POST: Cidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,IdEstado,Preferencia")] Cidade cidade)
        {
            if (id != cidade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CidadeExists(cidade.Id))
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
            ViewData["IdEstado"] = new SelectList(_context.Estados, "Id", "Nome", cidade.IdEstado);
            return View(cidade);
        }

        // GET: Cidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cidades == null)
            {
                return NotFound();
            }

            var cidade = await _context.Cidades
                .Include(c => c.Estado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cidade == null)
            {
                return NotFound();
            }

            return View(cidade);
        }

        // POST: Cidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cidades == null)
            {
                return Problem("Entity set 'AppDbContext.Cidades'  is null.");
            }
            var cidade = await _context.Cidades.FindAsync(id);
            if (cidade != null)
            {
                _context.Cidades.Remove(cidade);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CidadeExists(int id)
        {
          return _context.Cidades.Any(e => e.Id == id);
        }

        [AllowAnonymous]
        public async Task<ActionResult> DetalhesCidades(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("index");
            }

            var cidades = this._context.TextoCidades
                                              .Include(i => i.Cidade)
                                              .ThenInclude(i => i.ImagensCidades)
                                              .Where(w => w.IdCidade == id).ToList();

            //Todo: Arrumar o retorno quando não encontrar o estado com o id informado
            if (cidades == null)
            {

                return RedirectToAction("index");
            }

            return View("Cidade", cidades);
        }
    }
}
