using Claustromania.DataContexts;
using Claustromania.Dtos;
using Claustromania.Models;
using Microsoft.EntityFrameworkCore;

namespace Claustromania.Services
{
    public class PessoaService
    {
        private readonly AppDbContext _context;

        public PessoaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Pessoa>> GetAll()
        {
            return await _context.Pessoa.ToListAsync();
        }

        public async Task<Pessoa?> GetOneById(int id)
        {
            try
            {
                return await _context.Pessoa
                    .SingleOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Pessoa?> Create(PessoaDto pessoaDto)
        {
            try
            {
                var newPessoa = new Pessoa
                {
                    Nome = pessoaDto.Nome,
                    CPF = pessoaDto.CPF,
                    DataNascimento = pessoaDto.DataNascimento.Date, // Garante apenas a parte da data
                    Sexo = pessoaDto.Sexo,
                    Email = pessoaDto.Email
                };

                await _context.Pessoa.AddAsync(newPessoa);
                await _context.SaveChangesAsync();

                return newPessoa;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Pessoa?> Update(int id, PessoaDto pessoaDto)
        {
            try
            {
                var pessoa = await GetOneById(id);

                if (pessoa is null)
                    return null;

                pessoa.Nome = pessoaDto.Nome;
                pessoa.CPF = pessoaDto.CPF;
                pessoa.DataNascimento = pessoaDto.DataNascimento.Date; // Garante apenas a parte da data
                pessoa.Sexo = pessoaDto.Sexo;
                pessoa.Email = pessoaDto.Email;

                _context.Pessoa.Update(pessoa);
                await _context.SaveChangesAsync();

                return pessoa;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Pessoa?> Delete(int id)
        {
            try
            {
                var pessoa = await _context.Pessoa.FindAsync(id);

                if (pessoa == null)
                    return null;

                _context.Pessoa.Remove(pessoa);
                await _context.SaveChangesAsync();
                return pessoa;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Erro ao deletar pessoa: {ex.InnerException?.Message}");
                return null;
            }
        }

        private async Task<bool> Exist(int id)
        {
            return await _context.Pessoa.AnyAsync(c => c.Id == id);
        }
    }
}


