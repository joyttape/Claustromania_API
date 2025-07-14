using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Claustromania.Models
{
    [Table("transacao")]
    public class Transacao
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("valor")]
        public decimal Valor { get; set; }

        [Required]
        [Column("data")]
        public DateTime Data { get; set; }

        [Required]
        [Column("tipo")]
        public string Tipo { get; set; } = null!;

        [Column("forma_pagamento")]
        public string? FormaPagamento { get; set; }

        [Column("pagador")]
        public string? Pagador { get; set; } 

        [Column("valor_recebido")]
        public decimal? ValorRecebido { get; set; }

        [Column("troco")]
        public decimal? Troco { get; set; } 

        [Column("fk_pessoa")]
        public Guid? FkPessoa { get; set; }

        [ForeignKey(nameof(FkPessoa))]
        public virtual Pessoa? Pessoa { get; set; }

        [Required]
        [Column("fk_caixa")]
        public Guid FkCaixa { get; set; }

        [ForeignKey(nameof(FkCaixa))]
        public virtual Caixa Caixa { get; set; } = null!;

        [Column("fk_reserva")]
        public Guid? FkReserva { get; set; }  // FK para reserva

        [ForeignKey(nameof(FkReserva))]
        public virtual Reserva? Reserva { get; set; }
    }
}
