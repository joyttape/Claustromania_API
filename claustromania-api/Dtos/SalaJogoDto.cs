using System;

namespace Claustromania.DTOs
{
    public class SalaJogoDto
    {
        public Guid Id { get; set; }
        public Guid FkSala { get; set; }
        public Guid FkJogo { get; set; }
    }
}
