using Claustromania.DataContexts;
using Claustromania.Dtos;
using Claustromania.Models;
using Microsoft.EntityFrameworkCore;

namespace Claustromania.Services
{
    public class JogoService
    {
        private readonly AppDbContext _context;

        public JogoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Jogo>> GetAll()
        {
            var jogos = await _context.Jogo.ToListAsync();

            return jogos;
        }

        public async Task<Jogo?> GetOneById(int id)
        {
            try
            {
                return await _context.Jogo
                    .SingleOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Jogo?> Create(JogoDto jogos)
        {
            try
            {
                var nome = jogos.Nome;
                var descricao = jogos.Descricao;
                var duracao = jogos.Duracao;
                var dificuldade = jogos.Dificuldade;
                var preco = jogos.Preco;

                var newJogo = new Jogo

                {
                    Nome = jogos.Nome,
                    Descricao = jogos.Descricao,
                    Duracao = jogos.Duracao,
                    Dificuldade = jogos.Dificuldade,
                    Preco = jogos.Preco
                };

                await _context.Jogo.AddAsync(newJogo);
                await _context.SaveChangesAsync();

                return newJogo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Jogo?> Update(int id, JogoDto jogos)
        {
            try
            {
                var _jogo = await GetOneById(id);

                if (_jogo is null)
                {
                    return _jogo;
                }

                _jogo.Nome = jogos.Nome;
                _jogo.Descricao = jogos.Descricao;
                _jogo.Dificuldade = jogos.Dificuldade;
                _jogo.Preco = jogos.Preco;
                _jogo.Duracao = jogos.Duracao;
                
                _context.Jogo.Update(_jogo);
                await _context.SaveChangesAsync();

                return _jogo;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<Jogo?> Delete(int id)
        {
            try
            {
                var jogo = await _context.Jogo.FindAsync(id);

                if (jogo == null)
                    return null;

                _context.Jogo.Remove(jogo);
                await _context.SaveChangesAsync();
                return jogo;

            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Erro ao deletar sala: {ex.InnerException?.Message}");
                return null;
            }
        }


        private async Task<bool> Exist(int id)
        {
            return await _context.Jogo.AnyAsync(c => c.Id == id);
        }

    }
}
