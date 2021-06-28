using AutoMapper;
using GCSERP.MVC.Models;
using GCSERP.Produtos.Entidades.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GCSERP.MVC.Controllers
{
    [Route("produto-classificacao")]
    public class ProdutoClassificacaoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepositorioProdutosClassificacoes _repositorioProdutosClassificacoes;

        public ProdutoClassificacaoController(IMapper mapper,
            IRepositorioProdutosClassificacoes repositorioProdutosClassificacoes)
        {
            _mapper = mapper;
            _repositorioProdutosClassificacoes = repositorioProdutosClassificacoes;
        }

        //[HttpGet("")]
        [HttpGet("index")]
        [HttpGet("listar-classificacoes")]
        public async Task<IActionResult> Index()
        {
            var produtos = await _repositorioProdutosClassificacoes.ObterTodosAsync();
            var produtosVM = ProdutoClassificacaoViewModel.DelvoverListaVM(_mapper, produtos);

            return View(produtosVM);
        }

        // GET: ProdutoClassificacaoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProdutoClassificacaoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProdutoClassificacaoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdutoClassificacaoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProdutoClassificacaoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdutoClassificacaoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProdutoClassificacaoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
