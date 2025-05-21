using Claustromania.Models;
using Microsoft.EntityFrameworkCore;

namespace Claustromania.DataContexts
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Sala> Salas { get; set; }
        public DbSet<Unidade> Unidade { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Jogo> Jogo { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; } // Nova DbSet para a entidade Pessoa

        
    }
}