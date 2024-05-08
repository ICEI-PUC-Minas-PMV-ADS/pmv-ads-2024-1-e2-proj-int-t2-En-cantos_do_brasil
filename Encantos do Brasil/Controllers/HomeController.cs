using Encantos_do_Brasil.Models;
using Encantos_do_Brasil.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Security.Claims;

namespace Encantos_do_Brasil.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new CidadeEstadoViewModel();
            var userPref = User.FindFirstValue(ClaimTypes.Role);

            Random random = new Random();
            int x = random.Next(0, 4);
            int y = 12 - x;

            if (User.Identity.IsAuthenticated)
            {
                Preferencia preferenciaEnum = (Preferencia)Enum.Parse(typeof(Preferencia), userPref);
                var todasAsCidades = await _context.Cidades.Where(p => p.Preferencia == preferenciaEnum).ToListAsync();
                var cidadesEmbaralhadas = todasAsCidades.OrderBy(c => random.Next()).ToList();
                viewModel.Cidades = cidadesEmbaralhadas.Take(y).ToList();

                var todosOsEstados = await _context.Estados.Where(p => p.Preferencia == preferenciaEnum).ToListAsync();
                var estadosEmbaralhados = todosOsEstados.OrderBy(c => random.Next()).ToList();
                viewModel.Estados = estadosEmbaralhados.Take(x).ToList();
            }
            else
            {
                var todasAsCidades = await _context.Cidades.ToListAsync();
                var cidadesEmbaralhadas = todasAsCidades.OrderBy(c => random.Next()).ToList();
                viewModel.Cidades = cidadesEmbaralhadas.Take(y).ToList();

                var todosOsEstados = await _context.Estados.ToListAsync();
                var estadosEmbaralhados = todosOsEstados.OrderBy(c => random.Next()).ToList();
                viewModel.Estados = estadosEmbaralhados.Take(x).ToList();
            }
            return View(viewModel);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
