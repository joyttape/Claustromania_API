using System;


namespace Claustromania.DTOs
{
    public class ReservaDto
    {
        public Guid Id { get; set; }
        public DateTime DataReserva { get; set; }
        public decimal ValorTotal { get; set; }
        public ClienteDto? Cliente { get; set; }

        public Guid FkSalaJogo { get; set; }
 
    }
}
