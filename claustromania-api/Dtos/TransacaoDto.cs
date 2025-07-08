using System;

namespace Claustromania.DTOs
{
    public class TransacaoDto
    {
        public Guid Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataTransacao { get; set; }
        public string FormaPagamento { get; set; }
        public Guid FkCaixa { get; set; }
        public Guid? FkPessoa { get; set; }
    }
}
