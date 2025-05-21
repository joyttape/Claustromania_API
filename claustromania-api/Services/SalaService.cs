using Claustromania.DataContexts;
using Claustromania.Dtos;
using Claustromania.Models;
using Microsoft.EntityFrameworkCore;

namespace Claustromania.Services
{
    public class SalaService
    {
        private readonly AppDbContext _context;

        public SalaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Sala>> GetAll()
        {
            var list = await _context.Salas.ToListAsync();

            return list;
        }

        public async Task<Sala?> GetOneById(int id)
        {
            try
            {
                return await _context.Salas
                    .SingleOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Sala?> Create(SalaDto sala)
        {
            try
            {
              
                var newSala = new Sala

                {
                    Numero = sala.Numero,
                    Jogadores_num = sala.Jogadores_num,
                    Status = sala.Status
                };

                await _context.Salas.AddAsync(newSala);
                await _context.SaveChangesAsync();

                return newSala;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public async Task<Sala?> Update(int id, SalaDto salas)
        {
            try
            {
                var _sala = await GetOneById(id);

                if (_sala is null)
                {
                    return _sala;
                }

                _sala.Numero = salas.Numero;
                _sala.Status = salas.Status;
                _sala.Jogadores_num = salas.Jogadores_num;

                _context.Salas.Update(_sala);
                await _context.SaveChangesAsync();

                return _sala;
            }
            catch (Exception ex)
            {
                    throw ex;
            }
            
        }

        public async Task<Sala?> Delete(int id)
        {
            try
            {
                var sala = await _context.Salas.FindAsync(id);

                if (sala == null)
                    return null;

                _context.Salas.Remove(sala);
                await _context.SaveChangesAsync();
                return sala;

            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Erro ao deletar sala: {ex.InnerException?.Message}");
                return null;
            }
        }


        private async Task<bool> Exist(int id)
        {
            return await _context.Salas.AnyAsync(c => c.Id == id);
        }
    }
}
