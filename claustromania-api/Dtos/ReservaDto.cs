﻿using Claustromania.Dtos;
using System;


namespace Claustromania.DTOs
{
    public class ReservaDto
    {
        public Guid Id { get; set; }
        public DateTime DataReserva { get; set; }
        public TimeSpan HoraReserva { get; set; }
        public int NumeroJogadores { get; set; }
        public decimal ValorTotal { get; set; }
        public string Status { get; set; } = "reservado";
        public string? Observacoes { get; set; }
        public string FormaPagamento { get; set; }
        public Guid FkCliente { get; set; }
        public Guid FkSalaJogo { get; set; }
    }
}