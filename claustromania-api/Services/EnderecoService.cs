using Claustromania.DataContexts;
using Claustromania.Dtos;
using Claustromania.Models;
using Microsoft.EntityFrameworkCore;


namespace Claustromania.Services
{
    public class EnderecoService
    {

        private readonly AppDbContext _context;

        public EnderecoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Endereco>> GetAll()
        {
            var list = await _context.Endereco.ToListAsync();

            return list;
        }

        public async Task<Endereco?> GetOneById(int id)
        {
            try
            {
                return await _context.Endereco
                    .SingleOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Endereco?> Create(EnderecoDto end)
        {
            try
            {
                var logradouro = end.Logradouro;
                var cep = end.CEP;
                var cidade = end.Cidade;
                var numero = end.Numero;
                var estado = end.Estado;
                var bairro = end.Bairro;
                var complemento = end.Complemento;

                var newEnd = new Endereco

                {
                   Logradouro = end.Logradouro,
                   Cidade = end.Cidade,
                   Numero = end.Numero,
                   Estado = end.Estado,
                   Bairro = end.Bairro,
                   Complemento = end.Complemento,
                   CEP = end.CEP
                };

                await _context.Endereco.AddAsync(newEnd);
                await _context.SaveChangesAsync();

                return newEnd;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Endereco?> Update(int id, EnderecoDto end)
        {
            try
            {
                var _end = await GetOneById(id);

                if (_end is null)
                {
                    return _end;
                }

                _end.Logradouro = end.Logradouro;
                _end.CEP = end.CEP;
                _end.Cidade = end.Cidade;
                _end.Numero = end.Numero;
                _end.Estado = end.Estado;
                _end.Bairro = end.Bairro;
                _end.Complemento = end.Complemento;

                _context.Endereco.Update(_end);
                await _context.SaveChangesAsync();

                return _end;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<Endereco?> Delete(int id)
        {
            try
            {
                var end = await _context.Endereco.FindAsync(id);

                if (end == null)
                    return null;

                _context.Endereco.Remove(end);
                await _context.SaveChangesAsync();
                return end;

            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Erro ao deletar sala: {ex.InnerException?.Message}");
                return null;
            }
        }


        private async Task<bool> Exist(int id)
        {
            return await _context.Endereco.AnyAsync(c => c.Id == id);
        }

    }
}
