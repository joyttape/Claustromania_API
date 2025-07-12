using AutoMapper;
using Claustromania.Models;
using Claustromania.Dtos;
using Claustromania.DTOs;
using System;

namespace Claustromania.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Pessoa, PessoaDto>()
                .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => src.Endereco))
                .ReverseMap();

            CreateMap<Funcionario, FuncionarioDto>()
                .ForMember(dest => dest.Pessoa, opt => opt.MapFrom(src => src.Pessoa))
                .ReverseMap();

            CreateMap<Endereco, EnderecoDto>().ReverseMap();

            CreateMap<Unidade, UnidadeDto>()
                .ForMember(dest => dest.Endereco,opt => opt.MapFrom(src => src.Endereco))
                .ForMember(dest => dest.HorarioAbertura, opt => opt.MapFrom(src => src.HorarioAbertura.HasValue ? src.HorarioAbertura.Value.ToString("hh\\:mm\\:ss") : null))
                .ForMember(dest => dest.HorarioFechamento, opt => opt.MapFrom(src => src.HorarioFechamento.HasValue ? src.HorarioFechamento.Value.ToString("hh\\:mm\\:ss") : null));
            CreateMap<UnidadeDto, Unidade>()
                .ForMember(dest => dest.HorarioAbertura, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.HorarioAbertura) ? (TimeSpan?)TimeSpan.ParseExact(src.HorarioAbertura, "hh\\:mm\\:ss", System.Globalization.CultureInfo.InvariantCulture) : null))
                .ForMember(dest => dest.HorarioFechamento, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.HorarioFechamento) ? (TimeSpan?)TimeSpan.ParseExact(src.HorarioFechamento, "hh\\:mm\\:ss", System.Globalization.CultureInfo.InvariantCulture) : null));

            CreateMap<Sala, SalaDto>().ReverseMap();


            CreateMap<CaixaDto, Caixa>()
    .ForMember(dest => dest.Funcionario, opt => opt.MapFrom(src => src.Funcionario))
    .ForMember(dest => dest.Unidade, opt => opt.MapFrom(src => src.Unidade))
    .ForMember(dest => dest.DataHoraAbertura, opt => opt.MapFrom(src => src.DataHoraAbertura))
    .ForMember(dest => dest.DataHoraFechamento, opt => opt.MapFrom(src => src.DataHoraFechamento))
    .ForMember(dest => dest.FkFuncionario, opt => opt.Ignore()) // ou calcule do dto.Funcionario.Id se quiser
    .ForMember(dest => dest.FkUnidade, opt => opt.Ignore());   // ou calcule do dto.Unidade.Id se quiser

            CreateMap<Caixa, CaixaDto>()
                .ForMember(dest => dest.Funcionario, opt => opt.MapFrom(src => src.Funcionario))
                .ForMember(dest => dest.Unidade, opt => opt.MapFrom(src => src.Unidade));
            CreateMap<Caixa, CaixaResumidoDto>()
    .ForMember(dest => dest.FkFuncionario, opt => opt.MapFrom(src => src.FkFuncionario))
    .ForMember(dest => dest.FkUnidade, opt => opt.MapFrom(src => src.FkUnidade))
    .ReverseMap();
            CreateMap<Caixa, CaixaResumidoDto>().ReverseMap();


            CreateMap<Jogo, JogoDto>().ReverseMap();

            CreateMap<Cliente, ClienteDto>()
                .ForMember(dest => dest.Pessoa, opt => opt.MapFrom(src => src.Pessoa))
                .ReverseMap();

            CreateMap<Reserva, ReservaDto>()
                .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.Cliente))
                .ReverseMap();

            CreateMap<SalaJogo, SalaJogoDto>().ReverseMap();
            CreateMap<Transacao, TransacaoDto>().ReverseMap();
        }
    }
}
