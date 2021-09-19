using ApiApplication.ViewModel;
using AutoMapper;
using Business.Models;

namespace ApiApplication.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();

            // DE -> PARA
            // Conta -> Model
            CreateMap<Conta, PagamentoViewModel>()
                .ForMember(prop => prop.TipoRecorrenciaDescricao, opt => opt.MapFrom(src => src.TipoRecorrencia.ToString()))
                .ReverseMap();

            // Pagamento -> Model
            CreateMap<Pagamento, PagamentoViewModel>()
                .ForPath(dest => dest.TipoRecorrenciaDescricao, opt => opt.MapFrom(src => src.Conta.TipoRecorrencia))
                .ForPath(dest => dest.TipoRecorrencia, opt => opt.MapFrom(src => src.Conta.TipoRecorrencia))
                .ForPath(dest => dest.DescricaoFornecedor, opt => opt.MapFrom(src => src.Conta.DescricaoFornecedor))
             .ReverseMap()
                .ForPath(dest => dest.Conta.DescricaoFornecedor, opt => opt.MapFrom(src => src.DescricaoFornecedor))
                .ForPath(dest => dest.Conta.TipoRecorrencia, opt => opt.MapFrom(src => src.TipoRecorrencia));



            // 
            /*
              CreateMap<TipoRecorrenciaEnum, string>().ConvertUsing(src => src.ToString());
              CreateMap<Produto, ProdutoViewModel>()
                .ForMember(dest => dest.NomeFornecedor, opt => opt.MapFrom(src => src.Fornecedor.Nome));
             */
        }
    }
}
