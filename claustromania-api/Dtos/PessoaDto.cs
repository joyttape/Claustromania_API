using System.ComponentModel.DataAnnotations;

namespace Claustromania.Dtos
{
    public class PessoaDto
    {
        [Required]
        public required string Nome { get; set; }

        [Required]
        public required string CPF { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }

        [Required]
        public required string Sexo { get; set; }

        public string? Email { get; set; }
    }
}