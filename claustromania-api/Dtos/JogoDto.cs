using System.ComponentModel.DataAnnotations;

namespace Claustromania.Dtos
{
    public class JogoDto
    {
        [Required]
        public required string Nome { get; set; }

        [Required]
        public required string Descricao { get; set; }

        [Required]
        public required string Duracao { get; set; }

        [Required]
        public required string Dificuldade { get; set; }

        [Required]
        public required double Preco { get; set; }
    }
}
