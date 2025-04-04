using Loja.Data;
using Loja.Data.Model;

namespace Loja.UI.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Produto> ProdutosDisponiveis { get; set; }
    }
}
