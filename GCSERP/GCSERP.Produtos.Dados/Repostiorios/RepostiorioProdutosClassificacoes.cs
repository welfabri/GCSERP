using GCS.ERP.Core.Interfaces;
using GCSERP.Produtos.Dados.Contextos;
using GCSERP.Produtos.Entidades.Classes;
using GCSERP.Produtos.Entidades.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GCSERP.Produtos.Dados.Repostiorios
{
    public class RepostiorioProdutosClassificacoes : IRepositorioProdutosClassificacoes
    {
        private readonly DbContextProdutos _contexto;

        public IGCSUnityOfWork UOW => _contexto;

        public RepostiorioProdutosClassificacoes(DbContextProdutos contextProdutos)
        {
            _contexto = contextProdutos;
        }
        public void Adicionar(ProdutoClassificacao produtoClassificacao)
            => _contexto.ProdutosClassificacoes.Add(produtoClassificacao);

        public async Task ApagarAsync(int id)
        {
            var o = await ObterAsync(id);
            _contexto.ProdutosClassificacoes.Remove(o);
        }

        public void Atualizar(ProdutoClassificacao produtoClassificacao)
            => _contexto.ProdutosClassificacoes.Update(produtoClassificacao);

        public void Dispose()
        {
            _contexto?.Dispose();
        }

        public async Task<ProdutoClassificacao> ObterAsync(int id)
            => await _contexto.ProdutosClassificacoes.FindAsync(id);

        public async Task<List<ProdutoClassificacao>> ObterTodosAsync()
            => await _contexto.ProdutosClassificacoes.AsNoTracking().ToListAsync();

        public async Task<List<ProdutoClassificacao>> ObterTodosAtivosAsync()
        => await _contexto.ProdutosClassificacoes.AsNoTracking().ToListAsync();
    }
}
