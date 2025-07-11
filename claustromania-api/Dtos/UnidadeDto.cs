using System;

namespace Claustromania.DTOs
{
    public class UnidadeDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Capacidade { get; set; }
        public string? HorarioAbertura { get; set; }
        public string? HorarioFechamento { get; set; }
        public string Telefone { get; set; }
        public bool Ativa { get; set; }
    }
}

