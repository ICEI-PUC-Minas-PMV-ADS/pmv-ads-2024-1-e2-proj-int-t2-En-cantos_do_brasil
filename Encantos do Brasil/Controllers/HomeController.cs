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


        public async Task<IActionResult> Index(int? id)
        {
            var viewModel = new CidadeEstadoViewModel();
            var userPref = User.FindFirstValue(ClaimTypes.Role);

            //Random random = new Random();
            //int x = random.Next(0, 4);
            //int y = 12 - x;

            List<RegiaoPais> cidadesEstados;
            if (User.Identity.IsAuthenticated)
            {

                Preferencia preferenciaEnum = (Preferencia)Enum.Parse(typeof(Preferencia), userPref);


                if (id == null)
                {
                    cidadesEstados = _context.RegioesPais.Include(r => r.Estados)
                                                            .ThenInclude(i => i.Cidades)
                                                                .ThenInclude(i => i.ImagensCidades)
                                                            .Include(r => r.Estados)
                                                                .ThenInclude(i => i.ImagensEstado)
                                                            .Where(w => w.Estados.Any(a => a.Preferencia == preferenciaEnum))
                                                            .ToList();
                }
                else
                {
                    cidadesEstados = _context.RegioesPais.Include(r => r.Estados)
                                                            .ThenInclude(i => i.Cidades)
                                                                .ThenInclude(i => i.ImagensCidades)
                                                            .Include(r => r.Estados)
                                                                .ThenInclude(i => i.ImagensEstado)
                                                            .Where(w => w.Id == id)
                                                            .ToList();
                }

                viewModel.ImagemEstados = cidadesEstados.SelectMany(s => s.Estados.SelectMany(s => s.ImagensEstado)).ToList();
                viewModel.ImagemCidades = cidadesEstados.SelectMany(s => s.Estados.SelectMany(s => s.Cidades.SelectMany(sm => sm.ImagensCidades))).ToList();

                //var todasAsCidades = await _context.Cidades.Where(p => p.Preferencia == preferenciaEnum).ToListAsync();
                //var cidadesEmbaralhadas = todasAsCidades.OrderBy(c => random.Next()).ToList();
                //viewModel.Cidades = cidadesEmbaralhadas.Take(y).ToList();

                //var todosOsEstados = await _context.Estados.Where(p => p.Preferencia == preferenciaEnum).ToListAsync();
                //var estadosEmbaralhados = todosOsEstados.OrderBy(c => random.Next()).ToList();
                //viewModel.Estados = estadosEmbaralhados.Take(x).ToList();
            }
            else
            {
                cidadesEstados = _context.RegioesPais.AsNoTracking().Include(r => r.Estados)
                                                            .ThenInclude(i => i.Cidades)
                                                                .ThenInclude(i => i.ImagensCidades)
                                                            .Include(r => r.Estados)
                                                                .ThenInclude(i => i.ImagensEstado)
                                                            .ToList();


                viewModel.ImagemEstados = cidadesEstados.SelectMany(s => s.Estados.SelectMany(s => s.ImagensEstado)).ToList();
                viewModel.ImagemCidades = cidadesEstados.SelectMany(s => s.Estados.SelectMany(s => s.Cidades.SelectMany(sm => sm.ImagensCidades))).ToList();

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

        public IActionResult FazerPesquisa(string pesquisa)
        {
            if (!string.IsNullOrEmpty(pesquisa))
            {

                var regiao = _context.RegioesPais.Where(w => w.Nome.Contains(pesquisa)).FirstOrDefault();

                return RedirectToAction("Index", new { id = regiao.Id });
            }

            return RedirectToAction("Index");
        }

        public List<string> SugestaoDePesquisa(string pesquisa)
        {
            var regioes = _context.RegioesPais.Where(w => w.Nome.Contains(pesquisa)).Select(s => s.Nome).ToList();
            return regioes;
        }
    }
}
