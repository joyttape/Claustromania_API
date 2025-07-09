using AutoMapper;
using Claustromania.Data;
using Claustromania.Dtos;
using Claustromania.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<PessoaDto>> GetAll()
        {
            var pessoas = await _context.Pessoas.ToListAsync();
            return _mapper.Map<IEnumerable<PessoaDto>>(pessoas);
        }

        public async Task<PessoaDto?> GetOneById(Guid id)
        {
            var pessoa = await _context.Pessoas.FindAsync(id);
            return pessoa is null ? null : _mapper.Map<PessoaDto>(pessoa);
        }

        public async Task<PessoaDto> Create(PessoaDto dto)
        {

            var pessoa = _mapper.Map<Pessoa>(dto);
            pessoa.Id = Guid.NewGuid(); // garantir que a chave seja definida aqui
            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync();
            return _mapper.Map<PessoaDto>(pessoa);
        }

        public async Task<PessoaDto?> Update(Guid id, PessoaDto dto)
        {
            var pessoa = await _context.Pessoas.FindAsync(id);
            if (pessoa is null) return null;

            
            _mapper.Map(dto, pessoa); // Mapeia as outras propriedades

            await _context.SaveChangesAsync();
            return _mapper.Map<PessoaDto>(pessoa);
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
                                 .Include(p => p.Endereco) // Inclui o Endereco da Pessoa
                                 .Where(p => p.Endereco != null && p.Endereco.Cidade == cidade)
                                 .ToListAsync();
        }

        // Se você adicionou o método para autenticação, ele também precisará ser ajustado
        public async Task<Pessoa?> GetPessoaByEmailOrCpfAsync(string identifier)
        {
            return await _context.Pessoas
                                 .FirstOrDefaultAsync(p => p.Email == identifier || p.CPF == identifier);
        }
    }
}
