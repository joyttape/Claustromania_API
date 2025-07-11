
using System.ComponentModel.DataAnnotations;
using Claustromania.DTOs;

namespace Claustromania.Dtos
{
    public class PessoaDto


    {

        public Guid Id { get; set; }  




        public  string Nome { get; set; }


        public  string CPF { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }


        public  string Sexo { get; set; }

        public string? Email { get; set; }

        public string Senha { get; set; }

        public EnderecoDto Endereco { get; set; }




    }
}
