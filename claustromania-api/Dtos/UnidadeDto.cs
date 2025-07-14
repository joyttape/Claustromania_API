using Claustromania.Models;
using Claustromania.Dtos;
using System;

namespace Claustromania.DTOs
{
    public class UnidadeDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Capacidade { get; set; }
        public string? HorarioAbertura { get; set; }
        public string? HorarioFechamento { get; set; }
        public string Telefone { get; set; }

        public string Cnpj { get; set; }

        public string DiaFunci { get; set; }
        public bool Ativa { get; set; }

        public EnderecoDto? Endereco { get; set; }
        public FuncionarioDto? Funcionario { get; set; }





    }
}