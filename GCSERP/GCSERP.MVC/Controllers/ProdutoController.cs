using AutoMapper;
using GCSERP.MVC.Models;
using GCSERP.Produtos.Entidades.Classes;
using GCSERP.Produtos.Entidades.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GCSERP.MVC.Controllers
{
    [Authorize]
    public class ProdutoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepositorioProdutos _repositorioProdutos;
        private readonly IRepositorioProdutosClassificacoes _repositorioProdutosClassificacoes;

        public ProdutoController(IMapper mapper, 
            IRepositorioProdutos repositorioProdutos,
            IRepositorioProdutosClassificacoes repositorioProdutosClassificacoes)
        {
            _mapper = mapper;
            _repositorioProdutos = repositorioProdutos;
            _repositorioProdutosClassificacoes = repositorioProdutosClassificacoes;
        }

        //[HttpGet("")]
        [HttpGet("/produto/index")]
        [HttpGet("/produto/listar-produtos")]
        public async Task<IActionResult> Index()
        {
            var produtos = await _repositorioProdutos.ObterTodosAsync();
            var produtosVM = ProdutoViewModel.DelvoverListaVM(_mapper, produtos);

            return View(produtosVM);
        }

        // GET: ProdutoClassificacao/detalhar/5
        [HttpGet("/produto/informacoes/{id}")]
        [HttpGet("/produto/detalhar/{id}")]
        public async Task<ActionResult> Detalhar(int id)
        {
            var produto = await _repositorioProdutos.ObterAsync(id);
            var produtoVM = ProdutoViewModel.DevolverProdutoVM(_mapper, produto);

            return View(produtoVM);
        }

        // GET: ProdutoClassificacao/novo
        [HttpGet("/produto/novo")]
        [HttpGet("/produto/criar")]
        [HttpGet("/produto/inserir")]
        public async Task<ActionResult> Criar()
        {
            var classificacoes = await _repositorioProdutosClassificacoes.ObterTodosAtivosAsync();
            ProdutoViewModel vm = ProdutoViewModel.Instanciar(classificacoes);

            return View(vm);
        }

        // POST: ProdutoClassificacao/novo
        [HttpPost("/produto/novo")]
        [HttpPost("/produto/criar")]
        [HttpGet("/produto/inserir")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(ProdutoViewModel produtoViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                if (produtoViewModel.Validar())
                {
                    Produto produto = produtoViewModel.Produto();
                    _repositorioProdutos.Adicionar(produto);
                    await _repositorioProdutos.UOW.CommitAsync();
                } 
                else
                {
                    ModelState.AddModelError(string.Empty, "Dados inválidos!");
                    return await Criar();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdutoClassificacao/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProdutoClassificacao/Edit/5
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

        //// GET: ProdutoClassificacao/Delete/5
        //public ActionResult Apagar(int id)
        //{
        //    return View();
        //}

        // DELETE: Produto/apagar/5
        [HttpDelete("/produto/apagar/{id}")]
        [HttpDelete("/produto/remover/{id}")]
        [HttpDelete("/produto/deletar/{id}")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Apagar(int id)
        {
            try
            {
                var produto = await _repositorioProdutos.ObterAsync(id);
                produto.Apagar();
                _repositorioProdutos.Atualizar(produto);
                await _repositorioProdutos.UOW.CommitAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet("/produto/abrir-classificacoes")]
        public async Task<IActionResult> AbrirClassificacao()
        {
            var produtos = await _repositorioProdutos.ObterTodosAsync();
            var produtosVM = ProdutoViewModel.DelvoverListaVM(_mapper, produtos);            

            return View(produtosVM);
        }
    }
}
