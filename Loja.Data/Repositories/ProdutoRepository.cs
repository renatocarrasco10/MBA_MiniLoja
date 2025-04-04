using Loja.Data.Context;
using Loja.Data.Model;
using Loja.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DataDbContext _context;

        public ProdutoRepository(DataDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Produto> Produtos => _context.Produtos.Include(c => c.Categoria);

        public IEnumerable<Produto> ProdutosDisponiveis => _context.Produtos
                                                             .Where(l => l.Ativo)
                                                             .Where(l => l.QuantidadeEstoque > 0)
                                                             .Include(c => c.Categoria);

        public Produto GetProdutoById(int produtoId)
        {
            Produto? produto = _context.Produtos.FirstOrDefault(l => l.Id == produtoId);
            return produto;
        }
        public IEnumerable<Produto> GetProdutosByCategoriaId(int categoriaId)
        {
            IEnumerable<Produto>? produtos = _context.Produtos.Where(p => p.CategoriaId == categoriaId);
            return produtos;
        }


    }
}
