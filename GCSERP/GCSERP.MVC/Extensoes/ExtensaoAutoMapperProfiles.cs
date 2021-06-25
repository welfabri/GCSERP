using AutoMapper;
using GCSERP.MVC.Models;
using GCSERP.Produtos.Entidades.Classes;

namespace GCSERP.MVC.Extensoes
{
    public class ExtensaoAutoMapperProfiles : Profile
    {
        public ExtensaoAutoMapperProfiles()
        {
            CreateMap<Produto, ProdutoViewModel>()
                .ReverseMap();
        }
    }
}
