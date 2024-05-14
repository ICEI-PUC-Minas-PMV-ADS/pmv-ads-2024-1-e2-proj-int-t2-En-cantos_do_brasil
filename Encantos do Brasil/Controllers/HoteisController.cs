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
    public class HoteisController : Controller
    {
        private readonly AppDbContext _context;

        public HoteisController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Hoteis 
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Hoteis.Include(h => h.Cidade);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Hoteis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hoteis == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hoteis
                .Include(h => h.Cidade)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // GET: Hoteis/Create
        public IActionResult Create()
        {
            ViewData["IdCidade"] = new SelectList(_context.Cidades, "Id", "Nome");
            return View();
        }

        // POST: Hoteis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Custo,IdCidade")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCidade"] = new SelectList(_context.Cidades, "Id", "Nome", hotel.IdCidade);
            return View(hotel);
        }

        // GET: Hoteis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hoteis == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hoteis.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }
            ViewData["IdCidade"] = new SelectList(_context.Cidades, "Id", "Nome", hotel.IdCidade);
            return View(hotel);
        }

        // POST: Hoteis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Custo,IdCidade")] Hotel hotel)
        {
            if (id != hotel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelExists(hotel.Id))
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
            ViewData["IdCidade"] = new SelectList(_context.Cidades, "Id", "Nome", hotel.IdCidade);
            return View(hotel);
        }

        // GET: Hoteis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hoteis == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hoteis
                .Include(h => h.Cidade)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // POST: Hoteis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hoteis == null)
            {
                return Problem("Entity set 'AppDbContext.Hoteis'  is null.");
            }
            var hotel = await _context.Hoteis.FindAsync(id);
            if (hotel != null)
            {
                _context.Hoteis.Remove(hotel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelExists(int id)
        {
          return _context.Hoteis.Any(e => e.Id == id);
        }
    }
}
