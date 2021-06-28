using GCS.ERP.Core.Interfaces;
using GCSERP.Produtos.Entidades.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GCSERP.Produtos.Entidades.Interfaces
{
    public interface IRepositorioProdutosClassificacoes : IGCSRepositorio<Produto>
    {
        IGCSUnityOfWork UOW { get; }

        Task<List<ProdutoClassificacao>> ObterTodosAsync();
        Task<List<ProdutoClassificacao>> ObterTodosAtivosAsync();
        Task<ProdutoClassificacao> ObterAsync(int id);

        void Adicionar(ProdutoClassificacao produtoClassificacao);
        void Atualizar(ProdutoClassificacao produtoClassificacao);
        Task ApagarAsync(int id);
    }
}
