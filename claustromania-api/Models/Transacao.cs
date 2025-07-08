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
        [Column("data_transacao")]
        public DateTime DataTransacao { get; set; }

        [Required]
        [Column("forma_pagamento")]
        public string FormaPagamento { get; set; }

        [Required]
        [Column("fk_caixa")]
        public Guid FkCaixa { get; set; }

        [Column("fk_pessoa")]
        public Guid? FkPessoa { get; set; }
    }
}
