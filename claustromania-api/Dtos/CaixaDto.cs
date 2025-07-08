using System;

namespace Claustromania.DTOs
{
    public class CaixaDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Guid FkUnidade { get; set; }
        public Guid FkFuncionario { get; set; }
        public DateTime DataHoraAbertura { get; set; }
        public DateTime? DataHoraFechamento { get; set; }
        public decimal ValorInicial { get; set; }
        public decimal? ValorFinal { get; set; }
        public int TotalTransacoes { get; set; }
        public string Status { get; set; }
        public string? Observacoes { get; set; }
    }
}