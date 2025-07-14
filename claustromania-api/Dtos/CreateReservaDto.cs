using System.ComponentModel.DataAnnotations;

namespace Claustromania.DTOs
{
    public class CreateReservaDto
    {
        public DateTime DataReserva { get; set; }
        public TimeSpan HoraReserva { get; set; }
        public int NumeroJogadores { get; set; }
        public decimal ValorTotal { get; set; }
        public string? Observacoes { get; set; }
        public string FormaPagamento { get; set; }
        public Guid FkCliente { get; set; }
        public Guid FkSalaJogo { get; set; }
    }
}