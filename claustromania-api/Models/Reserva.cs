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
        [Column("valor_total")]
        public decimal ValorTotal { get; set; }

        [Required]
        [Column("fk_cliente")]
        public Guid FkCliente { get; set; }

        [Required]
        [Column("fk_sala_jogo")]

        public Guid FkSalaJogo { get; set; }


    }
}
