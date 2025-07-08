
using AutoMapper;
using Claustromania.Models;
using Claustromania.Dtos;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Claustromania.DTOs;

namespace Claustromania.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Pessoa, PessoaDto>().ReverseMap();
            CreateMap<Funcionario, FuncionarioDto>().ReverseMap();
            CreateMap<Endereco, EnderecoDto>().ReverseMap();
            CreateMap<Unidade, UnidadeDto>().ReverseMap();
            CreateMap<Sala, SalaDto>().ReverseMap();
            CreateMap<Caixa, CaixaDto>().ReverseMap();
            CreateMap<Jogo, JogoDto>().ReverseMap();
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<Reserva, ReservaDto>().ReverseMap();
            CreateMap<SalaJogo, SalaJogoDto>().ReverseMap();
            CreateMap<Transacao, TransacaoDto>().ReverseMap();

            CreateMap<Cliente, ClienteDetalhadoDto>();

            CreateMap<Endereco, EnderecoDetalhadoDto>();

            // Novos mapeamentos para CaixaDetalhadoDto
            CreateMap<Caixa, CaixaDetalhadoDto>();
            CreateMap<Funcionario, FuncionarioSimplesDto>()
                .ForMember(dest => dest.NomeFuncionario, opt => opt.MapFrom(src => src.Pessoa.Nome));

            CreateMap<Unidade, UnidadeSimplesDto>()
                .ForMember(dest => dest.Cidade, opt => opt.MapFrom(src => src.Endereco.Cidade)) 
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Endereco.Estado));

        }
    }
}
