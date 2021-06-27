using GCS.ERP.Core.Interfaces;
using GCSERP.Produtos.Entidades.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GCSERP.Produtos.Entidades.Interfaces
{
    public interface IRepositorioProdutos : IGCSRepositorio<Produto>
    {
        IGCSUnityOfWork UOW { get; }

        Task<List<Produto>> ObterTodosAsync();
        Task<Produto> ObterAsync(int id);

        void Adicionar(Produto produto);
        void Atualizar(Produto produto);
        Task ApagarAsync(int id);
    }
}
