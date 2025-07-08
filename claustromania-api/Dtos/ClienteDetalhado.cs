using Claustromania.Enums;

namespace Claustromania.Dtos
{
    public class ClienteDetalhadoDto
    {


        public Guid Id { get; set; }
        public NivelExperiencia NivelExperiencia { get; set; }

        // Propriedades detalhadas da Pessoa
        public PessoaDto Pessoa { get; set; }

    }
}
