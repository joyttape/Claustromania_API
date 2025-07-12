using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Claustromania.Models
{
    [Table("caixa")]
    public class Caixa
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("nome")]
        public string Nome { get; set; }

        [Required]
        [Column("fk_funcionario")]
        public Guid FkFuncionario { get; set; }

        [Required]
        [Column("data_hora_abertura")]
        public DateTime? DataHoraAbertura { get; set; }

        [Column("data_hora_fechamento")]
        public DateTime? DataHoraFechamento { get; set; }

        [Required]
        [Column("valor_inicial")]
        public decimal ValorInicial { get; set; }

        [Column("valor_final")]
        public decimal? ValorFinal { get; set; }

        [Column("total_transacoes")]
        public int TotalTransacoes { get; set; } = 0;

        [Required]
        [Column("status")]
        public string Status { get; set; }

        [Column("observacoes")]
        public string? Observacoes { get; set; }

        // Propriedade de navegação para Unidade
        [ForeignKey("FkUnidade")]
        public Unidade Unidade { get; set; } // Adicione esta linha

        [Required]
        [Column("fk_unidade")]
        public Guid FkUnidade { get; set; }

        // Propriedade de navegação para Funcionario
        [ForeignKey("FkFuncionario")]
        public Funcionario Funcionario { get; set; }

    }
}

