using Encantos_do_Brasil.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Encantos_do_Brasil.Controllers
{
    public class ImagensEstadosController : Controller
    {
        private readonly AppDbContext _context;

        public ImagensEstadosController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ExibirImagem(int id)
        {
            var imagem = await _context.ImagensEstados.FirstOrDefaultAsync(i => i.IdEstado == id);
            if (imagem != null)
            {
                return File(imagem.Dados, imagem.TipoConteudo);
            }
            return NotFound();
        }


        public IActionResult UploadImagem()
        {
            ViewData["IdEstado"] = new SelectList(_context.Estados, "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadImagem(IFormFile arquivo, int estadoId, TipoImagem tipoImagem)
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
            var imagem = new ImagemEstado
            {
                Nome = arquivo.FileName,
                TipoConteudo = arquivo.ContentType,
                Dados = dadosImagem,
                TipoImagem = tipoImagem,
                IdEstado = estadoId
            };

            _context.ImagensEstados.Add(imagem);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
