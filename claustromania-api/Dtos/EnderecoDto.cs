﻿using System;

namespace Claustromania.Dtos
{
    public class EnderecoDto
    {
        public Guid Id { get; set; }
        public string Logradouro { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Numero { get; set; }
        public string Estado { get; set; }
        public string Bairro { get; set; }
        public string? Complemento { get; set; }
    }
}