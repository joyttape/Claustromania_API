using AutoMapper;
using Claustromania.Data;
using Claustromania.Dtos;
using Claustromania.Models;
using Microsoft.EntityFrameworkCore;

namespace Claustromania.Services
{
    public class UnidadeService
    {
        private readonly ClaustromaniaDbContext _context;
        private readonly IMapper _mapper;

        public UnidadeService(ClaustromaniaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Unidade>> GetAllAsync()
        {
            return await _context.Unidades.Include(e => e.Endereco).Include(e=>e.Funcionario).ThenInclude(f=> f.Pessoa)
                .ToListAsync();
        }

        public async Task<Unidade?> GetByIdAsync(Guid id)
        {
            return await _context.Unidades.Include(e => e.Endereco)
        .Include(e => e.Funcionario)
            .ThenInclude(f => f.Pessoa)
        .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Unidade> CreateAsync(Unidade unidade)
        {
            unidade.Id = Guid.NewGuid();
            if (unidade.Endereco != null && unidade.Endereco.Id == Guid.Empty)
            {
                unidade.Endereco.Id = Guid.NewGuid();
                _context.Entry(unidade.Endereco).State = EntityState.Added;
            }
            _context.Unidades.Add(unidade);
            await _context.SaveChangesAsync();
            return unidade;
        }

        public async Task<Unidade> CreateWithEnderecoAsync(UnidadeCreateDto dto)
        {
            var endereco = _mapper.Map<Endereco>(dto.Endereco);
            _context.Enderecos.Add(endereco);
            await _context.SaveChangesAsync();

            var unidade = new Unidade
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome,
                Capacidade = dto.Capacidade,
                HorarioAbertura = dto.HorarioAbertura,
                HorarioFechamento = dto.HorarioFechamento,
                Cnpj = dto.Cnpj,
                DiaFunci = dto.DiaFunci,
                Telefone = dto.Telefone,
                Ativa = dto.Ativa,
                FkFuncionario = dto.FkFuncionario,
                FkEndereco = endereco.Id
            };

            _context.Unidades.Add(unidade);
            await _context.SaveChangesAsync();

            return unidade;
        }


        public async Task<bool> UpdateAsync(Unidade unidade)
        {
            var existing = await _context.Unidades.Include(u => u.Endereco).FirstOrDefaultAsync(u => u.Id == unidade.Id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(unidade);

            if (unidade.Endereco != null)
            {
                if (existing.Endereco == null)
                {
                    unidade.Endereco.Id = Guid.NewGuid();
                    _context.Entry(unidade.Endereco).State = EntityState.Added;
                    existing.Endereco = unidade.Endereco;
                }
                else
                {
                    _context.Entry(existing.Endereco).CurrentValues.SetValues(unidade.Endereco);
                }
            }
            else if (existing.Endereco != null)
            {
                _context.Enderecos.Remove(existing.Endereco);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var unidade = await _context.Unidades.FindAsync(id);
            if (unidade == null) return false;

            _context.Unidades.Remove(unidade);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
