// DTOs/EnderecoDetalhadoDto.cs
using System;
using System.Collections.Generic;
using Claustromania.Dtos;

namespace Claustromania.DTOs
{
    public class EnderecoDetalhadoDto
    {
       

        // Lista de Pessoas associadas a este endereço
        public List<PessoaDto> Pessoas { get; set; }
    }
}
