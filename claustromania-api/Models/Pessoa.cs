using System.ComponentModel.DataAnnotations.Schema;

namespace Claustromania.Models
{
    [Table("pessoa")]
    public class Pessoa
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nome")]
        public required string Nome { get; set; }

        [Column("CPF")]
        public required string CPF { get; set; }

        [Column("Data_Nascimento", TypeName = "date")] // Especifica o tipo DATE do SQL
        public DateTime DataNascimento { get; set; }

        [Column("Sexo")]
        public required string Sexo { get; set; }

        [Column("Email")]
        public string? Email { get; set; }
    }
}