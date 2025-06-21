// Controllers/TreinoController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ex_full.Models;
using ex_full.Data;

namespace ex_full.Controllers
{
    public class TreinoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TreinoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Detalhes(int id = 1)
        {
            var treino = await _context.Treinos
                .Include(t => t.Exercicios)
                .Include(t => t.Comentarios)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (treino == null)
            {
                return RedirectToAction("Detalhes", new { id = 1 });
            }

            // Ordenar comentários por data (mais recente primeiro)
            treino.Comentarios = treino.Comentarios.OrderByDescending(c => c.DataCriacao).ToList();

            return View(treino);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarComentario(int treinoId, string comentario)
        {
            if (!string.IsNullOrWhiteSpace(comentario))
            {
                var novoComentario = new Comentario
                {
                    TreinoId = treinoId,
                    Texto = comentario.Trim(),
                    DataCriacao = DateTime.Now,
                    Usuario = "Usuário Anônimo"
                };

                _context.Comentarios.Add(novoComentario);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Detalhes", new { id = treinoId });
        }

        [HttpPost]
        public async Task<IActionResult> EditarComentario(int comentarioId, string novoTexto, int treinoId)
        {
            var comentario = await _context.Comentarios.FindAsync(comentarioId);

            if (comentario != null && !string.IsNullOrWhiteSpace(novoTexto))
            {
                comentario.Texto = novoTexto.Trim();
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Detalhes", new { id = treinoId });
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirComentario(int comentarioId, int treinoId)
        {
            var comentario = await _context.Comentarios.FindAsync(comentarioId);

            if (comentario != null)
            {
                _context.Comentarios.Remove(comentario);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Detalhes", new { id = treinoId });
        }

        // API para buscar texto do comentário (para edição)
        [HttpGet]
        public async Task<IActionResult> ObterComentario(int id)
        {
            var comentario = await _context.Comentarios.FindAsync(id);

            if (comentario == null)
            {
                return NotFound();
            }

            return Json(new { texto = comentario.Texto });
        }
    }
}