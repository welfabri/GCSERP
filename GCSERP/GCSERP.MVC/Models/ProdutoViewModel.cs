using AutoMapper;
using GCS.ERP.Core.Classes;
using GCSERP.Produtos.Entidades.Classes;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GCSERP.MVC.Models
{
    public class ProdutoViewModel : GCSViewModelBase
    {
        private readonly IMapper _mapper;
        public ProdutoViewModel()
            => Classificacoes = new List<SelectListItem>();

        public ProdutoViewModel(IMapper mapper)
            : this()
            => _mapper = mapper;   

        [Display(Name ="Código Interno")]
        public int Id { get; set; }

        [Display(Name ="Código Externo")]
        public string CodigoExterno { get; set; }
        
        [Required(ErrorMessage = CAMPOOBRIGATORIO)]
        [MaxLength(250)]
        public string Nome { get; set; }
        
        [Display(Name ="Descrição")]
        [MaxLength(2500)]
        public string Descricao { get; set; }

        public string Marca { get; set; }
        
        [Required(ErrorMessage = CAMPOOBRIGATORIO)]
        [Display(Name = "Grupo da Unidade de Medida")]
        public int UnidadeMedidaClassificacao { get; set; }
        
        [Required(ErrorMessage = CAMPOOBRIGATORIO)]
        [Display(Name = "Unidade")]
        public int UnidadeMedidaEstoque { get; set; }

        public int NCM { get; set; }
        
        [Display(Name = "Observações")]
        public string Observacoes { get; set; }

        [Display(Name = "Classificação")]
        [Required(ErrorMessage = CAMPOOBRIGATORIO)]
        public int ProdutoClassificacaoId { get; set; }

        public List<SelectListItem> Classificacoes { get; set; }

        [Display(Name = "Versão Interna")]
        public byte VersaoInterna { get; set; }

        public bool FoiApagado { get; set; }
        
        [Display(Name = "Inserido Im")]
        public DateTime DataInsercao { get; set; }

        [Display(Name = "Última Atualização Em")]
        public DateTime DataAtualizacao { get; set; }

        [Display(Name = "Removido Em")]
        public DateTime DataRemocao { get; set; }

        internal void PreencherClassificacoes(List<ProdutoClassificacao> classificacoes)
            => classificacoes.ForEach(
                x => Classificacoes.Add(
                    new SelectListItem(x.Nome, x.Id.ToString())));

        internal static ProdutoViewModel DevolverProdutoVM(IMapper mapper,
            Produto produto)
        {
            ProdutoViewModel result = new(mapper);
            result._mapper.Map(produto, result);

            return result;
        }

        internal static List<ProdutoViewModel> DelvoverListaProdutosVM(IMapper mapper,
            List<Produto> produtos)
        {
            List<ProdutoViewModel> result = new();
            produtos.ForEach(x => result.Add(DevolverProdutoVM(mapper, x)));

            return result;
        }        
    }
}
