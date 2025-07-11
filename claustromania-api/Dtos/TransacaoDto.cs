using Claustromania.Dtos;
using System;

namespace Claustromania.DTOs
{
    public class TransacaoDto
    {
        public Guid Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataTransacao { get; set; }
        public string FormaPagamento { get; set; }
        public string Tipo { get; set; }

        public CaixaDto Caixa { get; set; }
        public PessoaDto? Pessoa { get; set; }
    }
}
