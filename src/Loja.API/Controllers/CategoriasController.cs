using Loja.Data.Context;
using Loja.Data.Model;
using Loja.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
namespace Loja.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/categorias")]
    public class CategoriasController : ControllerBase
    {
        private readonly DataDbContext _dbContext;
        private readonly IProdutoRepository _produtoRepository;

        public CategoriasController(DataDbContext context, IProdutoRepository produtoRepository)
        {
            _dbContext = context;
            _produtoRepository = produtoRepository;
        }


        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
        {
            if (_dbContext.Categorias == null) return NotFound();

            return await _dbContext.Categorias.ToListAsync();
        }

        [AllowAnonymous]
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            if (_dbContext.Categorias == null) return Problem("Erro ao criar uma Categoria, contate o suporte!");

            var categoria = await _dbContext.Categorias.FindAsync(id);

            if (categoria == null) return NotFound();

            return categoria;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> PostCategoria(Categoria categoria)
        {

            if (_dbContext.Categorias == null) return NotFound();

            if (!ModelState.IsValid)
            {
                return ValidationProblem(validationProblemDetailsPersonalizada(ModelState));
            }
            _dbContext.Categorias.Add(categoria);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCategoria), new { id = categoria.Id }, categoria);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> PutCategoria(int id, Categoria categoria)
        {
            if (id != categoria.Id) return BadRequest();
            if (!ModelState.IsValid)
            {
                return ValidationProblem(validationProblemDetailsPersonalizada(ModelState));
            }

            _dbContext.Categorias.Entry(categoria).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(id))
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
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            if (_dbContext.Categorias == null) return NotFound();

            if (_produtoRepository.GetProdutosByCategoriaId(id).Any()) return Problem("Não é possível excluir esta categoria, pois há produtos associados a ela!");

            var categoria = await _dbContext.Categorias.FindAsync(id);

            if (categoria == null) return NotFound();

            _dbContext.Categorias.Remove(categoria);
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

        private bool CategoriaExists(int id)
        {
            return (_dbContext.Categorias?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
