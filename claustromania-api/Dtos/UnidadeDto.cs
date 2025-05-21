using System.ComponentModel.DataAnnotations;

namespace Claustromania.Dtos
{
    public class UnidadeDto
    {

        [Required]
        public required string NomeUnidade { get; set; }

        [Required]
        public required int Capacidade { get; set; }

        [Required]
        public required string Horario_Func { get; set; }

        [Required]
        public required string Telefone { get; set; }

        [Required]
        public required bool Status { get; set; }

    }
}
