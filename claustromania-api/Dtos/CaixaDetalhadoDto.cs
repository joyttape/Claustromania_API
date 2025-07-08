namespace Claustromania.DTOs
{
    public class CaixaDetalhadoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataHoraAbertura { get; set; }
        public DateTime? DataHoraFechamento { get; set; }
        public decimal ValorInicial { get; set; }
        public decimal? ValorFinal { get; set; }
        public int TotalTransacoes { get; set; }
        public string Status { get; set; }
        public string? Observacoes { get; set; }

        // Propriedades detalhadas do Funcionário
        public FuncionarioSimplesDto Funcionario { get; set; }

        // Propriedades detalhadas da Unidade
        public UnidadeSimplesDto Unidade { get; set; }
    }

    // DTOs auxiliares para não expor os modelos completos
    public class FuncionarioSimplesDto
    {
        public string NomeFuncionario { get; set; }
        public string Cargo { get; set; } // Assumindo que Funcionario tem uma propriedade Cargo
    }

    public class UnidadeSimplesDto
    {
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}

