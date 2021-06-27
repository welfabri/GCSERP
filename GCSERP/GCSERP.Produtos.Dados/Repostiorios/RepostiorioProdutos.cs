using GCS.ERP.Core.Interfaces;
using GCSERP.Produtos.Dados.Contextos;
using GCSERP.Produtos.Entidades.Classes;
using GCSERP.Produtos.Entidades.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GCSERP.Produtos.Dados.Repostiorios
{
    public class RepostiorioProdutos : IRepositorioProdutos
    {
        private readonly DbContextProdutos _contexto;

        public IGCSUnityOfWork UOW => _contexto;

        public RepostiorioProdutos(DbContextProdutos contextProdutos)
        {
            _contexto = contextProdutos;
        }
        public void Adicionar(Produto produto)
            => _contexto.Produtos.Add(produto);

        public async Task ApagarAsync(int id)
        {
            var o = await ObterAsync(id);
            _contexto.Produtos.Remove(o);
        }

        public void Atualizar(Produto produto)
            => _contexto.Produtos.Update(produto);

        public void Dispose()
        {
            _contexto?.Dispose();
        }

        public async Task<Produto> ObterAsync(int id)
            => await _contexto.Produtos.FindAsync(id);

        public async Task<List<Produto>> ObterTodosAsync()
            => await _contexto.Produtos.AsNoTracking().ToListAsync();
    }
}
