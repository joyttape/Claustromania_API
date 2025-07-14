using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Claustromania.Models
{
    [Table("sala_jogo")]
    public class SalaJogo
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("fk_sala")]
        public Guid FkSala { get; set; }

        [Required]
        [Column("fk_jogo")]
        public Guid FkJogo { get; set; }

        [ForeignKey("FkSala")]
        public Sala Sala { get; set; }

        [ForeignKey("FkJogo")]
        public Jogo Jogo { get; set; }
    }
}
