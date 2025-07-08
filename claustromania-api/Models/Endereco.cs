
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Claustromania.Models
{
    [Table("endereco")]
    public class Endereco
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("logradouro")]
        public string Logradouro { get; set; }

        [Required]
        [Column("cep")]
        [StringLength(9)]
        public string CEP { get; set; }

        [Required]
        [Column("cidade")]
        public string Cidade { get; set; }

        [Required]
        [Column("numero")]
        public string Numero { get; set; }

        [Required]
        [Column("estado")]
        [StringLength(2)]
        public string Estado { get; set; }

        [Required]
        [Column("bairro")]
        public string Bairro { get; set; }

        [Column("complemento")]
        public string? Complemento { get; set; }

        public ICollection<Pessoa> Pessoas { get; set; } // <-- Adicione esta linha


    }
}