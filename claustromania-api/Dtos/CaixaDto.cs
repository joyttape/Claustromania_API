using System.ComponentModel.DataAnnotations;

namespace Claustromania.Dtos
{
    public class CaixaDto
    {
        [Required]
        public required DateTime DataHoraAbertura { get; set; }

        public DateTime? DataHoraFechamento { get; set; }

        [Required]
        public required decimal ValorInicial { get; set; }

        public decimal? ValorFinal { get; set; }

        public int? TotalTransacoes { get; set; }

        [Required]
        public required string Status { get; set; }

        [Required]
        public required string FuncionarioNome { get; set; }

        public string? Observacoes { get; set; }
    }
}
