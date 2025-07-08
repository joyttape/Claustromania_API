using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Claustromania.Enums;

namespace Claustromania.Models
{
    [Table("jogo")]
    public class Jogo
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("nome")]
        public string Nome { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("duracao")]
        public string Duracao { get; set; }

        [Column("dificuldade")]
        public DificuldadeJogo? Dificuldade { get; set; }

        [Column("preco")]
        public decimal? Preco { get; set; }
    }
}
