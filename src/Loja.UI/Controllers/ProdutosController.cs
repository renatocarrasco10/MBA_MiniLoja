
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Loja.Data.Context;
using Loja.Data.Model;
using Microsoft.AspNetCore.Authorization;

namespace Loja.UI.Controllers
{

    [Authorize]
    public class ProdutosController : Controller
    {
        private readonly DataDbContext _context;

        public ProdutosController(DataDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        { 
            string? vendedorId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value; 

            var dataDbContext = _context.Produtos.Include(p => p.Categoria).Include(p => p.Vendedor).Where(p => p.VendedorId == vendedorId);
            return View(await dataDbContext.ToListAsync());
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .Include(p => p.Categoria)
                .Include(p => p.Vendedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Descricao");
            ViewData["VendedorId"] = new SelectList(_context.Vendedores, "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,ImagemUrl,Preco,QuantidadeEstoque,Ativo,CategoriaId, Imagem")] Produto produto)
        {
 
            if (ModelState.IsValid)
            {
                produto.ImagemUrl = await UploadArquivoAsync(produto.Imagem);

                produto.DataCadastro = DateTime.Now;
                produto.VendedorId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Descricao", produto.CategoriaId);
            ViewData["VendedorId"] = new SelectList(_context.Vendedores, "Id", "Id", produto.VendedorId);
            return View(produto);
        }     

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Descricao", produto.CategoriaId);
            ViewData["VendedorId"] = new SelectList(_context.Vendedores, "Id", "Id", produto.VendedorId);
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,ImagemUrl,Preco,QuantidadeEstoque,Ativo,CategoriaId, Imagem")] Produto produto)
        {
            if (id != produto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    produto.ImagemUrl = await UploadArquivoAsync(produto.Imagem);

                    produto.DataCadastro = DateTime.Now;
                    produto.VendedorId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Descricao", produto.CategoriaId);
            ViewData["VendedorId"] = new SelectList(_context.Vendedores, "Id", "Id", produto.VendedorId);
            return View(produto);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .Include(p => p.Categoria)
                .Include(p => p.Vendedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.Id == id);
        }

        private async Task<string> UploadArquivoAsync(IFormFile? Imagem)
        {
            if (Imagem != null && Imagem.Length > 0)
            {
                // Define o caminho onde o arquivo será salvo
                var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                var caminhoArquivo = Path.Combine(caminhoPasta, Imagem.FileName);

                // Cria a pasta caso não exista
                if (!Directory.Exists(caminhoPasta))
                {
                    Directory.CreateDirectory(caminhoPasta);
                }

                // Salva o arquivo no servidor
                using (var stream = new FileStream(caminhoArquivo, FileMode.Create))
                {
                    await Imagem.CopyToAsync(stream);
                }
                return "/uploads/" + Imagem.FileName;
            }
            return "";
            
        }
    }
}
