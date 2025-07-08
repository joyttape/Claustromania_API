using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Claustromania.Models
{
    [Table("funcionario")]
    public class Funcionario
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("cargo")]
        public string Cargo { get; set; }

        [Column("salario")]
        public decimal? Salario { get; set; }

        [Column("data_contratacao")]
        public DateTime? DataContratacao { get; set; }

        [Column("turno")]
        public string? Turno { get; set; }

        [Required]
        [Column("fk_pessoa")]
        public Guid FkPessoa { get; set; }

        [ForeignKey("FkPessoa")]
        public Pessoa Pessoa { get; set; }
    }
}
