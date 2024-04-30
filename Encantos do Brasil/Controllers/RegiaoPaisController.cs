using Encantos_do_Brasil.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    }
}
