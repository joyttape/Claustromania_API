using System;
using Claustromania.Models;
using Claustromania.Enums;
using Claustromania.Dtos;

namespace Claustromania.DTOs
{
    public class ClienteDto
    {
        public Guid Id { get; set; }
        public NivelExperiencia NivelExperiencia { get; set; }
        public PessoaDto Pessoa { get; set; }

    }
}
