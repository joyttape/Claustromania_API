using System.ComponentModel.DataAnnotations.Schema;

namespace Claustromania.Models
{
    [Table("unidade")]

    public class Unidade
    {
        public int Id { get; set; }

        [Column("NomeUnidade")]
        public required string NomeUnidade { get; set; }

        [Column("Capacidade")]

        public required int Capacidade { get; set; }

        [Column("Horario_Func")]

        public required string Horario_Func {  get; set; }

        [Column("Telefone")]
        public required string Telefone { get; set; }

        [Column("Status_uni")]
        public required bool Status_uni { get; set; }

    }
}
