using System.ComponentModel.DataAnnotations.Schema;

namespace Claustromania.Models
{
    [Table("jogo")]

    public class Jogo
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public required string Nome { get; set; }

        [Column("descricao")]
        public required string Descricao { get; set; }

        [Column("duracao")]
        public required string Duracao { get; set; }

        [Column("dificuldade")]
        public required string Dificuldade { get; set; }

        [Column("preco")]
        public required double Preco { get; set; }
    }
}
