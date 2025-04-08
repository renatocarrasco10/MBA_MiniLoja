using Loja.Data.Context;
using Loja.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace Loja.API.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    public class CategoriasController : ControllerBase
    {
        private readonly DataDbContext _dbContext;

        public CategoriasController(DataDbContext context)
        {
            _dbContext = context;
        }


    }
}
