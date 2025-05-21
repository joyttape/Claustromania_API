using System.ComponentModel.DataAnnotations.Schema;

namespace Claustromania.Models
{
    [Table ("funcionario")]

    public class Funcionario
    {
        [Column ("Id")]
        public int Id { get; set; }

        [Column("Cargo")]
        public required string Cargo { get; set; }

        [Column("Salario")]
        public required double Salario { get; set; }

        [Column("Data_Contratacao")]
        public required string data_contratacao { get; set; }

        [Column("Turno")]
        public required string Turno { get; set; }


    }
}
