using Loja.Data.Context;
using Loja.Data.Model;
using Loja.Data.Repositories;
using Loja.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace Loja.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/produtos")]
    public class ProdutosController : ControllerBase
    {
        private readonly DataDbContext _dbContext;
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController(DataDbContext context, IProdutoRepository produtoRepository)
        {
            _dbContext = context;
            _produtoRepository = produtoRepository;
        }


        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            if (_dbContext.Produtos == null) return NotFound();

            return await _dbContext.Produtos.ToListAsync();
        }

        [AllowAnonymous]
        [HttpGet("byCategoria/{idCategoria:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public ActionResult<IEnumerable<Produto>> GetProdutosbyCategoria(int idCategoria)
        {
            if (_produtoRepository.GetProdutosByCategoriaId(idCategoria) == null) return NotFound();

            return _produtoRepository.GetProdutosByCategoriaId(idCategoria).ToList();
        }

        [AllowAnonymous]
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            if (_dbContext.Produtos == null) return Problem("Erro ao criar um Produto, contate o suporte!");

            var produto = await _dbContext.Produtos.FindAsync(id);

            if (produto == null) return NotFound();

            return produto;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> PostProduto(Produto produto)
        {

            if (_dbContext.Produtos == null) return NotFound();

            if (!ModelState.IsValid) 
            {
                return ValidationProblem(validationProblemDetailsPersonalizada(ModelState));
            }
            _dbContext.Produtos.Add(produto);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduto), new { id = produto.Id }, produto);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> PutProduto(int id,Produto produto)
        {
            if (id != produto.Id) return BadRequest();
            if (!ModelState.IsValid)
            {
                return ValidationProblem(validationProblemDetailsPersonalizada(ModelState));
            }

            _dbContext.Produtos.Entry(produto).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(id))
                {
                    return NotFound();
                }
                else 
                {
                    throw;
                }
            }
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            if (_dbContext.Produtos == null) return NotFound();
            
            var produto = await _dbContext.Produtos.FindAsync(id);

            if (produto == null) return NotFound();

            _dbContext.Produtos.Remove(produto);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private ValidationProblemDetails validationProblemDetailsPersonalizada(ModelStateDictionary ModelState)

        {
            return new ValidationProblemDetails(ModelState)
            {
                Title = "Um ou mais erros de validação ocorreram!"
            };
        }

        private bool ProdutoExists(int id)
        {
            return (_dbContext.Produtos?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
