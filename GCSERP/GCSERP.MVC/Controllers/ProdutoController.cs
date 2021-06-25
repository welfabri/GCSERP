using AutoMapper;
using GCSERP.MVC.Models;
using GCSERP.Produtos.Entidades.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GCSERP.MVC.Controllers
{
    [Authorize]
    public class ProdutoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepositorioProdutos _repositorioProdutos;

        public ProdutoController(IMapper mapper, 
            IRepositorioProdutos repositorioProdutos)
        {
            _mapper = mapper;
            _repositorioProdutos = repositorioProdutos;
        }

        public async Task<IActionResult> Index()
        {
            var produtos = await _repositorioProdutos.ObterTodosAsync();
            var produtosVM = ProdutoViewModel.DelvoverListaProdutosVM(_mapper, produtos);

            return View(produtosVM);
        }
    }
}
