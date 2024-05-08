using Encantos_do_Brasil.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Encantos_do_Brasil.Controllers
{
    public class ImagensController : Controller
    {
        private readonly AppDbContext _context;

        public ImagensController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index() 
        {
            return View(); 
        }

        public IActionResult ExibirImagem(int id)
        {
            var imagem = _context.Imagens.FirstOrDefault(i => i.Id == id);
            if (imagem != null)
            {
                return File(imagem.Dados, imagem.TipoConteudo);
            }
            return NotFound();
        }

        public IActionResult UploadImagem()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadImagem(IFormFile arquivo)
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
            var imagem = new Imagem
            {
                Nome = arquivo.FileName,
                TipoConteudo = arquivo.ContentType,
                Dados = dadosImagem
            };

            _context.Imagens.Add(imagem);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
