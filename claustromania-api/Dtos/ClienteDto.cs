using System;
using Claustromania.Enums;

namespace Claustromania.DTOs
{
    public class ClienteDto
    {
        public Guid Id { get; set; }
        public NivelExperiencia NivelExperiencia { get; set; }
        public Guid FkPessoa { get; set; }
    }
}
