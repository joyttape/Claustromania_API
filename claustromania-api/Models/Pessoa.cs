using System.ComponentModel.DataAnnotations.Schema;

namespace Claustromania.Models
{
    [Table("pessoa")]
    public class Pessoa
    {
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("Nome")]
        public required string? Nome { get; set; }

        [Column("CPF")]
        public required string? CPF { get; set; }

        [Column("Data_Nascimento", TypeName = "date")]
        public DateTime? DataNascimento { get; set; }

        [Column("Sexo")]
        public required string? Sexo { get; set; }


        [Column("Telefone")]

        public required string? Telefone { get; set; }

        [Column("Email")]
        public string? Email { get; set; }
        // Chave estrangeira para Endereco (se uma pessoa tem um endereço)
        [Column("fk_endereco")] 
        public Guid? FkEndereco { get; set; }
        
        // Propriedade de navegação para Endereco
        [ForeignKey("FkEndereco")]
        public Endereco? Endereco { get; set; } 



        [Column("senha_hash")]
        public string? Senha { get; set; }

    }
}