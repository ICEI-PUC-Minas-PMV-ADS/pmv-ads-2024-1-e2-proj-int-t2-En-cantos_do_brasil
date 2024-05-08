using Encantos_do_Brasil.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Encantos_do_Brasil.Controllers
{
    public class RegiaoPaisController : Controller
    {
        private readonly AppDbContext _context;

        public RegiaoPaisController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dados = await _context.RegioesPais.ToListAsync();

            return View(dados);
        }


        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Nome")] RegiaoPais regiaoPais)
        {


            if (ModelState.IsValid)
            {
                _context.Add(regiaoPais);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(regiaoPais);
        }

    }

}
