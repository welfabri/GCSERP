using AutoMapper;
using GCS.ERP.Core.Classes;
using GCSERP.Produtos.Entidades.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GCSERP.MVC.Models
{
    public class ProdutoClassificacaoViewModel : GCSViewModelBase
    {
        private readonly IMapper _mapper;

        public ProdutoClassificacaoViewModel() { }

        public ProdutoClassificacaoViewModel(IMapper mapper)
            : this()
            => _mapper = mapper;

        [Display(Name = "Código Interno")]
        public int Id { get; set; }

        [Display(Name = "Código Externo")]
        public string CodigoExterno { get; set; }

        [Required(ErrorMessage = CAMPOOBRIGATORIO)]
        [MaxLength(250)]
        public string Nome { get; set; }

        public bool Ativo { get; set; } = true;

        internal static ProdutoClassificacaoViewModel DevolverVM(IMapper mapper,
            ProdutoClassificacao produto)
        {
            ProdutoClassificacaoViewModel result = new(mapper);
            result._mapper.Map(produto, result);

            return result;
        }

        internal static List<ProdutoClassificacaoViewModel> DelvoverListaVM(IMapper mapper, 
            List<ProdutoClassificacao> produtos)
        {
            List<ProdutoClassificacaoViewModel> result = new();
            produtos.ForEach(x => result.Add(DevolverVM(mapper, x)));

            return result;

        }
    }
}
