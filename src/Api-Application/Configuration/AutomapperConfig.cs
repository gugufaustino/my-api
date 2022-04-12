using ApiApplication.ViewModel;
using AutoMapper;
using Business.Models;
using System.Collections;
using System.Collections.Generic;

namespace ApiApplication.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Modelo, ModeloViewModel>();
            CreateMap<ModeloViewModel, Modelo>().ForMember(prop => prop.ModeloTipoCasting, opt => opt.MapFrom<MyResolvers>());

            // DE -> PARA
            // Conta -> Model
            CreateMap<Conta, PagamentoViewModel>()
                .ForMember(prop => prop.TipoRecorrenciaDescricao, opt => opt.MapFrom(src => src.TipoRecorrencia.ToString()))
                .ReverseMap();

            CreateMap<Fornecedor, FornecedorViewModel>()
                .ForMember(prop => prop.Cep, opt => opt.MapFrom(src => src.Endereco.Cep))
                .ForMember(prop => prop.Logradouro, opt => opt.MapFrom(src => src.Endereco.Logradouro))
                .ForMember(prop => prop.Numero, opt => opt.MapFrom(src => src.Endereco.Numero))
                .ForMember(prop => prop.Complemento, opt => opt.MapFrom(src => src.Endereco.Complemento))
                .ForMember(prop => prop.Bairro, opt => opt.MapFrom(src => src.Endereco.Bairro))
                .ForMember(prop => prop.NomeMunicipio, opt => opt.MapFrom(src => src.Endereco.NomeMunicipio))
                .ForMember(prop => prop.SiglaUf, opt => opt.MapFrom(src => src.Endereco.SiglaUf))
                .ReverseMap();


            // Pagamento -> Model
            CreateMap<Pagamento, PagamentoViewModel>()
                .ForPath(dest => dest.TipoRecorrenciaDescricao, opt => opt.MapFrom(src => src.Conta.TipoRecorrencia))
                .ForPath(dest => dest.TipoRecorrencia, opt => opt.MapFrom(src => src.Conta.TipoRecorrencia))
                .ForPath(dest => dest.DescricaoFornecedor, opt => opt.MapFrom(src => src.Conta.DescricaoFornecedor))
             .ReverseMap()
                .ForPath(dest => dest.Conta.DescricaoFornecedor, opt => opt.MapFrom(src => src.DescricaoFornecedor))
                .ForPath(dest => dest.Conta.TipoRecorrencia, opt => opt.MapFrom(src => src.TipoRecorrencia));

            /*
              CreateMap<TipoRecorrenciaEnum, string>().ConvertUsing(src => src.ToString());
              CreateMap<Produto, ProdutoViewModel>()
                .ForMember(dest => dest.NomeFornecedor, opt => opt.MapFrom(src => src.Fornecedor.Nome));
             */
        }
    }

    public class MyResolvers : IValueResolver<ModeloViewModel, Modelo, IEnumerable<ModeloTipoCasting>>
    {
        public IEnumerable<ModeloTipoCasting> Resolve(ModeloViewModel source, Modelo target, IEnumerable<ModeloTipoCasting> destMember, ResolutionContext context)
        {
            var obj = new List<ModeloTipoCasting>();
            foreach (var item in source.TipoCasting)
            {
                obj.Add(new ModeloTipoCasting { IdTipoCasting = (int)item });
            }
            return obj;
        }
    }
}
