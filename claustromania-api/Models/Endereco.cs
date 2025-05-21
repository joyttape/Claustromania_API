using System.ComponentModel.DataAnnotations.Schema;

namespace Claustromania.Models
{
    [Table ("endereco")]
    public class Endereco
    {

        [Column ("Id")]
        public int Id { get; set; }

        [Column("Logradouro")]
        public required string Logradouro { get; set; }

        [Column("Cidade")]
        public required string Cidade { get; set; }

        [Column("CEP")]
        public required string CEP { get; set; }

        [Column("Numero")]
        public required string Numero { get; set; }

        [Column("Estado")]
        public required string Estado { get; set; }

        [Column("Bairro")]
        public required string Bairro { get; set; }

        [Column("Complemento")]
        public required string Complemento { get; set; }

    }
}
