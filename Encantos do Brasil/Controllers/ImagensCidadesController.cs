using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Encantos_do_Brasil.Models;
using Microsoft.AspNetCore.Authorization;

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

        public async Task<IActionResult> ExibirImagem(int id, TipoImagem tipoImagem)
        {
            var imagem = await _context.ImagensCidades
    .FirstOrDefaultAsync(i => i.IdCidade == id && i.TipoImagem == tipoImagem);
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
        public async Task<IActionResult> UploadImagem(IFormFile arquivo, int cidadeId, TipoImagem tipoImagem)
        {
            if (arquivo == null || arquivo.Length == 0)
            {
                ModelState.AddModelError("Arquivo", "Por favor, selecione um arquivo para upload.");
                return RedirectToAction("Index", "Imagens");
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
                TipoImagem = tipoImagem,
                IdCidade = cidadeId
            };
            if (ModelState.IsValid)
            {
                _context.ImagensCidades.Add(imagem);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "ImagensCidades");
            }
            ViewData["IdCidade"] = new SelectList(_context.Cidades, "Id", "Nome");
            return View(imagem);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ImagensCidades == null)
            {
                return NotFound();
            }

            var imagem = await _context.ImagensCidades
                .Include(i => i.Cidade)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imagem == null)
            {
                return NotFound();
            }

            return View(imagem);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var imagem = await _context.ImagensCidades.FindAsync(id);
            if (imagem == null)
            {
                return NotFound();
            }

            _context.ImagensCidades.Remove(imagem);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "ImagensCidades");
        }
    }
}
