using System.ComponentModel.DataAnnotations.Schema;

namespace Claustromania.Models
{
    [Table("sala")]
    public class Sala
    {
        [Column ("Id")]
        public int Id { get; set; }

        [Column("Numero")]
        public required string Numero { get; set; }

        [Column("Capac_Jogadores")]
        public required int Jogadores_num { get; set; }

        [Column("Status_Sala")]
        public required bool Status { get; set; }
    }
}
