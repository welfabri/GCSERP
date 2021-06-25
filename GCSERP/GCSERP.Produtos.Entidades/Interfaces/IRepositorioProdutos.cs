using GCS.ERP.Core.Interfaces;
using GCS.ERP.Core.VO;
using GCSERP.Produtos.Entidades.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GCSERP.Produtos.Entidades.Interfaces
{
    public interface IRepositorioProdutos : IGCSRepositorio<Produto>
    {
        Task<List<Produto>> ObterTodosAsync();
        Task<Produto> ObterAsync(GCSBDId id);

        void Adicionar(Produto produto);
        void Atualizar(Produto produto);
        Task ApagarAsync(GCSBDId id);
    }
}
