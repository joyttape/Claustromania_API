namespace Claustromania.Dtos
{
    public class CaixaResumidoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = null!;
        public Guid FkFuncionario { get; set; }
        public Guid FkUnidade { get; set; }
        public DateTime? DataHoraAbertura { get; set; }
        public DateTime? DataHoraFechamento { get; set; }
        public decimal ValorInicial { get; set; }
        public decimal? ValorFinal { get; set; }
        public decimal TotalTransacoes { get; set; }
        public string Status { get; set; } = null!;
        public string? Observacoes { get; set; }
    }
}
