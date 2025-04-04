using Loja.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Data.Repositories.Interfaces
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> Produtos { get; }
        IEnumerable<Produto> ProdutosDisponiveis { get; }
        Produto GetProdutoById(int produtoId);
        IEnumerable<Produto> GetProdutosByCategoriaId(int categoriaId);

    }
}
