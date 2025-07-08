
using System.ComponentModel.DataAnnotations;

namespace Claustromania.Dtos
{
    public class PessoaDto


    {

        public Guid Id { get; set; }  // <--- ADICIONE ISSO




        public  string Nome { get; set; }


        public  string CPF { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }


        public  string Sexo { get; set; }

        public string? Email { get; set; }


        public Guid FkEndereco { get; set; }


        public string Senha { get; set; } // <-- Adicionado


    }
}
