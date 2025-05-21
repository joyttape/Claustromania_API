using System.ComponentModel.DataAnnotations;

namespace Claustromania.Dtos
{
    public class SalaDto
    {
        [Required]
        public required string Numero { get; set; }

        [Required]
        public required int Jogadores_num { get; set; }

        [Required]
        public required bool Status { get; set; }

    }
}
