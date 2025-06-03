using System.ComponentModel.DataAnnotations.Schema;

namespace Claustromania.Models
{
    [Table("caixa")]
    public class Caixa
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("data_hora_abertura")]
        public required DateTime DataHoraAbertura { get; set; }

        [Column("data_hora_fechamento")]
        public DateTime? DataHoraFechamento { get; set; }

        [Column("valor_inicial")]
        public required decimal ValorInicial { get; set; }

        [Column("valor_final")]
        public decimal? ValorFinal { get; set; }

        [Column("total_transacoes")]
        public decimal? TotalTransacoes { get; set; }

        [Column("status")]
        public required string Status { get; set; }

        [Column("funcionario_nome")]
        public required string FuncionarioNome { get; set; }

        [Column("observacoes")]
        public string? Observacoes { get; set; }
    }
}
