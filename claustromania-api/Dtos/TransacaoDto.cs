using Claustromania.Dtos;
using System;
using System.ComponentModel.DataAnnotations;

namespace Claustromania.DTOs
{
    public class TransacaoDto
    {
        public Guid Id { get; set; }
        public decimal Valor { get; set; }
        public string Data { get; set; } // Mantido como string para flexibilidade
        public string Tipo { get; set; } = "RESERVA"; // Valor padrão
        public string FormaPagamento { get; set; }
        public string Pagador { get; set; }
        public decimal? ValorRecebido { get; set; }
        public decimal? Troco { get; set; }

        [Required(ErrorMessage = "O ID do caixa é obrigatório")]
        public Guid FkCaixa { get; set; } // Nome exato do campo

        public Guid? FkPessoa { get; set; }
        public Guid? FkReserva { get; set; }
    }
}
