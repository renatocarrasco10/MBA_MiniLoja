using System.Diagnostics;
using Loja.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Loja.Data.Repositories.Interfaces;
using Loja.UI.ViewModels;

namespace Loja.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;

        public HomeController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                ProdutosDisponiveis = _produtoRepository.ProdutosDisponiveis
            };
            return View(homeViewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
