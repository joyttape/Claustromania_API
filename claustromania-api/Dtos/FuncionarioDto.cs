using System;

namespace Claustromania.DTOs
{
    public class FuncionarioDto
    {
        public Guid Id { get; set; }
        public string Cargo { get; set; }
        public decimal? Salario { get; set; }
        public DateTime? DataContratacao { get; set; }
        public string Turno { get; set; }
        public Guid FkPessoa { get; set; }
    }
}
