using System.ComponentModel.DataAnnotations;

namespace Claustromania.Dtos
{
    public class FuncionarioDto
    {

        [Required]
        public required string Cargo { get; set; }

        [Required]

        public required double Salario { get; set; }

        [Required]

        public required string data_contratacao { get; set; }

        [Required]

        public required string Turno { get; set; }
    }
}
