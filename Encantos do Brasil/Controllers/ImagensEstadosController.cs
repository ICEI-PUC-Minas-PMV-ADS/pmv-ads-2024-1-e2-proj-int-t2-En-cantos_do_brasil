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
    public class ImagensEstadosController : Controller
    {
        private readonly AppDbContext _context;

        public ImagensEstadosController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ExibirImagem(int id, TipoImagem tipoImagem)
        {
            var imagem = await _context.ImagensEstados
                .FirstOrDefaultAsync(i => i.IdEstado == id && i.TipoImagem == tipoImagem);
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
            if (ModelState.IsValid)
            {
                _context.ImagensEstados.Add(imagem);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "ImagensEstados");
            }
            ViewData["IdEstado"] = new SelectList(_context.Estados, "Id", "Nome");
            return View(imagem);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ImagensEstados == null)
            {
                return NotFound();
            }

            var imagem = await _context.ImagensEstados
                .Include(i => i.Estado)
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
            var imagem = await _context.ImagensEstados.FindAsync(id);
            if (imagem == null)
            {
                return NotFound();
            }

            _context.ImagensEstados.Remove(imagem);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "ImagensEstados");
        }
    }
}
