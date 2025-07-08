﻿using System;
using Claustromania.Enums;

namespace Claustromania.Dtos
{
    public class JogoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public string Duracao { get; set; }
        public DificuldadeJogo? Dificuldade { get; set; }
        public decimal? Preco { get; set; }
    }
}
