using Encantos_do_Brasil.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Encantos_do_Brasil.Controllers
{
    public class ImagensCidadesController : Controller
    {
        private readonly AppDbContext _context;

        public ImagensCidadesController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index() 
        {
            return View(); 
        }

        public async Task<IActionResult> ExibirImagem(int id)
        {
            var imagem = await _context.ImagensCidades.FirstOrDefaultAsync(i => i.IdCidade == id);
            if (imagem != null)
            {
                return File(imagem.Dados, imagem.TipoConteudo);
            }
            return NotFound();
        }


        public IActionResult UploadImagem()
        {
            ViewData["IdCidade"] = new SelectList(_context.Cidades, "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadImagem(IFormFile arquivo, int cidadeId)
        {
            if (arquivo == null || arquivo.Length == 0)
            {
                ModelState.AddModelError("Arquivo", "Por favor, selecione um arquivo para upload.");
                return RedirectToAction(nameof(Index));
            }

            // Lê os dados do arquivo e converte em um array de bytes
            byte[] dadosImagem;
            using (var memoryStream = new MemoryStream())
            {
                await arquivo.CopyToAsync(memoryStream);
                dadosImagem = memoryStream.ToArray();
            }

            // Salva os dados da imagem no banco de dados
            var imagem = new ImagemCidade
            {
                Nome = arquivo.FileName,
                TipoConteudo = arquivo.ContentType,
                Dados = dadosImagem,
                IdCidade = cidadeId
            };

            _context.ImagensCidades.Add(imagem);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
