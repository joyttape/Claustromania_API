using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Claustromania.Models
{
    [Table("sala")]
    public class Sala
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("nome")]
        public string Nome { get; set; }

        [Column("capacidade")]
        public int? Capacidade { get; set; }

        [Column("ativa")]
        public bool Ativa { get; set; } = true;

        [Column("fk_unidade")]
        public Guid? FkUnidade { get; set; }
    }
}
