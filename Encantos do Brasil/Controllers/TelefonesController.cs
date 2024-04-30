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
    public class TelefonesController : Controller
    {
        private readonly AppDbContext _context;

        public TelefonesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Telefones
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Telefones.Include(t => t.Hotel);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Telefones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Telefones == null)
            {
                return NotFound();
            }

            var telefoneHotel = await _context.Telefones
                .Include(t => t.Hotel)
                .FirstOrDefaultAsync(m => m.IdTelefone == id);
            if (telefoneHotel == null)
            {
                return NotFound();
            }

            return View(telefoneHotel);
        }

        // GET: Telefones/Create
        public IActionResult Create()
        {
            ViewData["IdHotel"] = new SelectList(_context.Hoteis, "Id", "Nome");
            return View();
        }

        // POST: Telefones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTelefone,Telefone,IdHotel")] TelefoneHotel telefoneHotel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(telefoneHotel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdHotel"] = new SelectList(_context.Hoteis, "Id", "Nome", telefoneHotel.IdHotel);
            return View(telefoneHotel);
        }

        // GET: Telefones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Telefones == null)
            {
                return NotFound();
            }

            var telefoneHotel = await _context.Telefones.FindAsync(id);
            if (telefoneHotel == null)
            {
                return NotFound();
            }
            ViewData["IdHotel"] = new SelectList(_context.Hoteis, "Id", "Nome", telefoneHotel.IdHotel);
            return View(telefoneHotel);
        }

        // POST: Telefones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTelefone,Telefone,IdHotel")] TelefoneHotel telefoneHotel)
        {
            if (id != telefoneHotel.IdTelefone)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(telefoneHotel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelefoneHotelExists(telefoneHotel.IdTelefone))
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
            ViewData["IdHotel"] = new SelectList(_context.Hoteis, "Id", "Nome", telefoneHotel.IdHotel);
            return View(telefoneHotel);
        }

        // GET: Telefones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Telefones == null)
            {
                return NotFound();
            }

            var telefoneHotel = await _context.Telefones
                .Include(t => t.Hotel)
                .FirstOrDefaultAsync(m => m.IdTelefone == id);
            if (telefoneHotel == null)
            {
                return NotFound();
            }

            return View(telefoneHotel);
        }

        // POST: Telefones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Telefones == null)
            {
                return Problem("Entity set 'AppDbContext.Telefones'  is null.");
            }
            var telefoneHotel = await _context.Telefones.FindAsync(id);
            if (telefoneHotel != null)
            {
                _context.Telefones.Remove(telefoneHotel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelefoneHotelExists(int id)
        {
          return _context.Telefones.Any(e => e.IdTelefone == id);
        }
    }
}
