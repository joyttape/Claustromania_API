using Claustromania.Models;
using Microsoft.EntityFrameworkCore;

namespace Claustromania.Data
{
    public class ClaustromaniaDbContext : DbContext
    {
        public ClaustromaniaDbContext(DbContextOptions<ClaustromaniaDbContext> options)
            : base(options) { }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Unidade> Unidades { get; set; }
        public DbSet<Caixa> Caixas { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<SalaJogo> SalaJogos { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }






        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>().ToTable("pessoa");

            modelBuilder.Entity<Jogo>()
                .Property(j => j.Dificuldade)
                .HasConversion<string>();

            modelBuilder.Entity<Transacao>()
    .HasOne<Pessoa>() // se quiser acessar Pessoa diretamente, adicione a navigation no model também
    .WithMany()
    .HasForeignKey(t => t.FkPessoa)
    .OnDelete(DeleteBehavior.SetNull); 


            modelBuilder.Entity<Transacao>()
    .HasOne<Caixa>()
    .WithMany()
    .HasForeignKey(t => t.FkCaixa);


            modelBuilder.Entity<Cliente>()
             .Property(c => c.NivelExperiencia)
         .HasConversion<string>();


            base.OnModelCreating(modelBuilder);
        }



    }
}

