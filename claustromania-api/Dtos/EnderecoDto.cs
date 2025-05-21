using System.ComponentModel.DataAnnotations;

namespace Claustromania.Dtos
{
    public class EnderecoDto
    {

        [Required]
        public required string Logradouro { get; set; }

        [Required]
        public required string Cidade { get; set; }

        [Required]
        public required string CEP { get; set; }

        [Required]
        public required string Numero { get; set; }

        [Required]
        public required string Estado { get; set; }

        [Required]
        public required string Bairro { get; set; }

        [Required]
        public required string Complemento { get; set; }

    }
}
