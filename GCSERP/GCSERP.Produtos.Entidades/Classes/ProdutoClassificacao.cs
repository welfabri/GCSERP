using GCS.ERP.Core.Classes;
using System.Collections.Generic;

namespace GCSERP.Produtos.Entidades.Classes
{
    public class ProdutoClassificacao : GCSEntityBDCadastro
    {
        public string Nome { get; set; }

        public IEnumerable<Produto> Produtos { get; set; }
    }
}
