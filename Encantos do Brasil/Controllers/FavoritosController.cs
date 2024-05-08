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
    public class FavoritosController : Controller
    {
        private readonly AppDbContext _context;

        public FavoritosController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var appDbContext = _context.Favoritos.Where(p => p.IdUsuario == int.Parse(userId)).
                Include(p => p.Cidade).Include(p => p.Hotel).Include(p => p.PontoTuristico);
            return View(await appDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Favoritos == null)
            {
                return NotFound();
            }

            var favorito = await _context.Favoritos
                .Include(p => p.Cidade)
                .Include(p => p.Hotel)
                .Include(p => p.PontoTuristico)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (favorito == null)
            {
                return NotFound();
            }

            return View(favorito);
        }

        public IActionResult Create()
        {
            ViewData["IdCidade"] = new SelectList(_context.Cidades, "Id", "Nome");
            ViewData["IdHotel"] = new SelectList(_context.Hoteis, "Id", "Nome");
            ViewData["IdPontoTuristico"] = new SelectList(_context.PontosTuristicos, "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdUsuario,IdCidade,IdHotel,IdPontoTuristico")] Favorito favorito)
        {
            // Aqui tem que trocar por um TryParse para evitar excessões e fazer um if para redirecionar para outra página caso dê erro
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            favorito.IdUsuario = int.Parse(userId);

            if (ModelState.IsValid)
            {
                _context.Add(favorito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCidade"] = new SelectList(_context.Cidades, "Id", "Nome", favorito.IdCidade);
            ViewData["IdHotel"] = new SelectList(_context.Hoteis, "Id", "Nome", favorito.IdHotel);
            ViewData["IdPontoTuristico"] = new SelectList(_context.PontosTuristicos, "Id", "Nome", favorito.IdPontoTuristico);
            return View(favorito);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Favoritos == null)
            {
                return NotFound();
            }

            var favorito = await _context.Favoritos.FindAsync(id);
            if (favorito == null)
            {
                return NotFound();
            }
            ViewData["IdCidade"] = new SelectList(_context.Cidades, "Id", "Nome", favorito.IdCidade);
            ViewData["IdHotel"] = new SelectList(_context.Hoteis, "Id", "Nome", favorito.IdHotel);
            ViewData["IdPontoTuristico"] = new SelectList(_context.PontosTuristicos, "Id", "Nome", favorito.IdPontoTuristico);
            return View(favorito);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdUsuario,IdCidade,IdHotel,IdPontoTuristico")] Favorito favorito)
        {
            if (id != favorito.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(favorito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FavoritoExists(favorito.Id))
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
            ViewData["IdCidade"] = new SelectList(_context.Cidades, "Id", "Nome", favorito.IdCidade);
            ViewData["IdHotel"] = new SelectList(_context.Hoteis, "Id", "Nome", favorito.IdHotel);
            ViewData["IdPontoTuristico"] = new SelectList(_context.PontosTuristicos, "Id", "Nome", favorito.IdPontoTuristico);
            return View(favorito);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Favoritos == null)
            {
                return NotFound();
            }

            var favorito = await _context.Favoritos
                .Include(p => p.Cidade)
                .Include(p => p.Hotel)
                .Include(p => p.PontoTuristico)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (favorito == null)
            {
                return NotFound();
            }

            return View(favorito);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Favoritos == null)
            {
                return Problem("Entity set 'AppDbContext.Favoritos'  is null.");
            }
            var favorito = await _context.Favoritos.FindAsync(id);
            if (favorito != null)
            {
                _context.Favoritos.Remove(favorito);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FavoritoExists(int id)
        {
          return _context.Favoritos.Any(e => e.Id == id);
        }
    }
}
