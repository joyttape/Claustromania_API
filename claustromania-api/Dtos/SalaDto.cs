using System;

namespace Claustromania.DTOs
{
    public class SalaDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int? Capacidade { get; set; }
        public bool Ativa { get; set; }
        public Guid? FkUnidade { get; set; }
    }
}
