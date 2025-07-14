using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Claustromania.Models
{
    [Table("reserva")]
    public class Reserva
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("data_reserva")]
        public DateTime DataReserva { get; set; }

        [Required]
        [Column("hora_reserva")]
        public TimeSpan HoraReserva { get; set; }

        [Required]
        [Column("numero_jogadores")]
        public int NumeroJogadores { get; set; }

        [Required]
        [Column("valor_total")]
        public decimal ValorTotal { get; set; }

        [Required]
        [Column("status")]
        public string Status { get; set; } = "reservado";

        [Column("observacoes")]
        public string? Observacoes { get; set; }

        [Required]
        [Column("forma_pagamento")]
        public string FormaPagamento { get; set; }

        [Required]
        [Column("fk_cliente")]
        public Guid FkCliente { get; set; }

        [Required]
        [Column("fk_sala_jogo")]
        public Guid FkSalaJogo { get; set; }

        [ForeignKey("FkCliente")]
        public Cliente? Cliente { get; set; }

        [ForeignKey("FkSalaJogo")]
        public SalaJogo? SalaJogo { get; set; }
    }
}