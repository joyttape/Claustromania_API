using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Claustromania.Enums;

namespace Claustromania.Models
{
    [Table("cliente")]
    public class Cliente
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("nivel_experiencia")]
        public NivelExperiencia NivelExperiencia { get; set; }

        [ForeignKey("FkPessoa")]
        public Pessoa Pessoa { get; set; }

        [Required]
        [Column("fk_pessoa")]
        public Guid FkPessoa { get; set; }
    }
}
