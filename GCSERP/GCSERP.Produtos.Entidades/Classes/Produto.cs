using GCS.ERP.Core.Classes;
using GCS.ERP.Core.Interfaces;
using GCS.ERP.Core.VO;
using System;

namespace GCSERP.Produtos.Entidades.Classes
{
    public class Produto : GCSEntityBDCadastro, IGSEntidadeAgregacao
    {
        protected Produto()
        {  }

        public Produto(string nome, string descricao, string marca, 
            GCSUnidadesMedidasClassificacao unidadeMedidaClassificacao, 
            GCSUnidadesMedidasGrandeza unidadeMedidaEstoque, 
            int ncm, string observacoes, int produtoClassificacaoId, 
            ProdutoClassificacao clasificacao)
            : this()
        {
            Nome = nome;
            Descricao = descricao;
            Marca = marca;
            UnidadeMedidaClassificacao = unidadeMedidaClassificacao;
            UnidadeMedidaEstoque = unidadeMedidaEstoque;
            NCM = ncm;
            Observacoes = observacoes;
            ProdutoClassificacaoId = produtoClassificacaoId;
            Clasificacao = clasificacao;
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string Marca { get; private set; }
        public GCSUnidadesMedidasClassificacao UnidadeMedidaClassificacao { get; private set; }
        public GCSUnidadesMedidasGrandeza UnidadeMedidaEstoque { get; private set; }
        public GCSERPNCM NCM { get; private set; }
        public string Observacoes { get; private set; }

        public int ProdutoClassificacaoId { get; private set; }
        public ProdutoClassificacao Clasificacao { get; private set; }
    }
}
