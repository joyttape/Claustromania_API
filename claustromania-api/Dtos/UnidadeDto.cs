using System;

namespace Claustromania.DTOs
{
    public class UnidadeDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int? Capacidade { get; set; }
        public TimeSpan? HorarioAbertura { get; set; }
        public TimeSpan? HorarioFechamento { get; set; }
        public string Telefone { get; set; }
        public bool Ativa { get; set; }
        public Guid? FkEndereco { get; set; }
        public Guid? FkGerente { get; set; }
    }
}
