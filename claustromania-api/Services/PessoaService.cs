using AutoMapper;
using Claustromania.Data;
using Claustromania.Dtos;
using Claustromania.Models;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net; 

namespace Claustromania.Services
{
    public class PessoaService
    {
        private readonly ClaustromaniaDbContext _context;
        private readonly IMapper _mapper;

        public PessoaService(ClaustromaniaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<PessoaDto?> GetOneById(Guid id)
        {
            var pessoa = await _context.Pessoas.FindAsync(id);
            return pessoa is null ? null : _mapper.Map<PessoaDto>(pessoa);
        }

        public async Task<Pessoa> CreateAsync(Pessoa pessoa)
        {
            pessoa.Id = Guid.NewGuid();
            if (pessoa.Endereco != null)
            {
                pessoa.Endereco.Id = Guid.NewGuid();
            }

            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync();
            return pessoa;
        }

        public async Task<bool> UpdateAsync(Pessoa pessoa)
        {
            var existing = await _context.Pessoas
                .Include(p => p.Endereco)
                .FirstOrDefaultAsync(p => p.Id == pessoa.Id);

            if (existing == null) return false;

            existing.Nome = pessoa.Nome;
            existing.CPF = pessoa.CPF;
            existing.DataNascimento = pessoa.DataNascimento;
            existing.Sexo = pessoa.Sexo;
            existing.Email = pessoa.Email;

            if (pessoa.Endereco != null)
            {
                if (existing.Endereco != null)
                {
                    existing.Endereco.Logradouro = pessoa.Endereco.Logradouro;
                    existing.Endereco.Numero = pessoa.Endereco.Numero;
                    existing.Endereco.Complemento = pessoa.Endereco.Complemento;
                    existing.Endereco.Bairro = pessoa.Endereco.Bairro;
                    existing.Endereco.Cidade = pessoa.Endereco.Cidade;
                    existing.Endereco.Estado = pessoa.Endereco.Estado;
                    existing.Endereco.CEP = pessoa.Endereco.CEP;
                }
                else
                {
                    pessoa.Endereco.Id = Guid.NewGuid();
                    existing.Endereco = pessoa.Endereco;
                }
            }
            else if (existing.Endereco != null)
            {
              
                _context.Entry(existing.Endereco).State = EntityState.Deleted;
                existing.Endereco = null;
            }

            await _context.SaveChangesAsync();
            return true;
        }




        public async Task<bool> Delete(Guid id)
        {
            var pessoa = await _context.Pessoas.FindAsync(id);
            if (pessoa is null) return false;

            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Pessoa>> GetPessoasByCidadeAsync(string cidade)
        {
            return await _context.Pessoas
                                 .Include(p => p.Endereco) 
                                 .Where(p => p.Endereco != null && p.Endereco.Cidade == cidade)
                                 .ToListAsync();
        }
    }
}