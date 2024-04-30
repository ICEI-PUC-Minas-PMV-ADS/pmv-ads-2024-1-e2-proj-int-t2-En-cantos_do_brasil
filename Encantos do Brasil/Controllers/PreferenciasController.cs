using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Encantos_do_Brasil.Models;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Encantos_do_Brasil.Controllers
{
    [Authorize]
    public class PreferenciasController : Controller
    {
        private readonly AppDbContext _context;

        public PreferenciasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Preferencias
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var appDbContext = _context.Preferencias.Where(p => p.IdUsuario == int.Parse(userId)).
                Include(p => p.Cidade).Include(p => p.Hotel).Include(p => p.PontoTuristico);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Preferencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Preferencias == null)
            {
                return NotFound();
            }

            var preferencia = await _context.Preferencias
                .Include(p => p.Cidade)
                .Include(p => p.Hotel)
                .Include(p => p.PontoTuristico)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (preferencia == null)
            {
                return NotFound();
            }

            return View(preferencia);
        }

        // GET: Preferencias/Create
        public IActionResult Create()
        {
            ViewData["IdCidade"] = new SelectList(_context.Cidades, "Id", "Nome");
            ViewData["IdHotel"] = new SelectList(_context.Hoteis, "Id", "Nome");
            ViewData["IdPontoTuristico"] = new SelectList(_context.PontosTuristicos, "Id", "Nome");
            return View();
        }

        // POST: Preferencias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdUsuario,IdCidade,IdHotel,IdPontoTuristico")] Preferencia preferencia)
        {
            // Aqui tem que trocar por um TryParse para evitar excessões e fazer um if para redirecionar para outra página caso dê erro
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            preferencia.IdUsuario = int.Parse(userId);

            if (ModelState.IsValid)
            {
                _context.Add(preferencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCidade"] = new SelectList(_context.Cidades, "Id", "Nome", preferencia.IdCidade);
            ViewData["IdHotel"] = new SelectList(_context.Hoteis, "Id", "Nome", preferencia.IdHotel);
            ViewData["IdPontoTuristico"] = new SelectList(_context.PontosTuristicos, "Id", "Nome", preferencia.IdPontoTuristico);
            return View(preferencia);
        }

        // GET: Preferencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Preferencias == null)
            {
                return NotFound();
            }

            var preferencia = await _context.Preferencias.FindAsync(id);
            if (preferencia == null)
            {
                return NotFound();
            }
            ViewData["IdCidade"] = new SelectList(_context.Cidades, "Id", "Nome", preferencia.IdCidade);
            ViewData["IdHotel"] = new SelectList(_context.Hoteis, "Id", "Nome", preferencia.IdHotel);
            ViewData["IdPontoTuristico"] = new SelectList(_context.PontosTuristicos, "Id", "Nome", preferencia.IdPontoTuristico);
            return View(preferencia);
        }

        // POST: Preferencias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdUsuario,IdCidade,IdHotel,IdPontoTuristico")] Preferencia preferencia)
        {
            if (id != preferencia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(preferencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PreferenciaExists(preferencia.Id))
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
            ViewData["IdCidade"] = new SelectList(_context.Cidades, "Id", "Nome", preferencia.IdCidade);
            ViewData["IdHotel"] = new SelectList(_context.Hoteis, "Id", "Nome", preferencia.IdHotel);
            ViewData["IdPontoTuristico"] = new SelectList(_context.PontosTuristicos, "Id", "Nome", preferencia.IdPontoTuristico);
            return View(preferencia);
        }

        // GET: Preferencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Preferencias == null)
            {
                return NotFound();
            }

            var preferencia = await _context.Preferencias
                .Include(p => p.Cidade)
                .Include(p => p.Hotel)
                .Include(p => p.PontoTuristico)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (preferencia == null)
            {
                return NotFound();
            }

            return View(preferencia);
        }

        // POST: Preferencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Preferencias == null)
            {
                return Problem("Entity set 'AppDbContext.Preferencias'  is null.");
            }
            var preferencia = await _context.Preferencias.FindAsync(id);
            if (preferencia != null)
            {
                _context.Preferencias.Remove(preferencia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PreferenciaExists(int id)
        {
          return _context.Preferencias.Any(e => e.Id == id);
        }
    }
}
