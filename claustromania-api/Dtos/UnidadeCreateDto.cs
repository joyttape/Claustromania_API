using System;

namespace Claustromania.Dtos
{
    public class UnidadeCreateDto
    {

        public string Nome { get; set; }
        public int? Capacidade { get; set; }
        public TimeSpan? HorarioAbertura { get; set; }
        public TimeSpan? HorarioFechamento { get; set; }
        public string Telefone { get; set; }

        public string Cnpj {  get; set; }

        public string DiaFunci {  get; set; }

        public bool Ativa { get; set; }

        public Guid FkFuncionario { get; set; } 

        public EnderecoDto Endereco { get; set; }
    }
}
