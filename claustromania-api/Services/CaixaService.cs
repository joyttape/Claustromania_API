using Claustromania.DataContexts;
using Claustromania.Dtos;
using Claustromania.Models;
using Microsoft.EntityFrameworkCore;

namespace Claustromania.Services
{
    public class CaixaService
    {
        private readonly AppDbContext _context;

        public CaixaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Caixa>> GetAll()
        {
            return await _context.Set<Caixa>().ToListAsync();
        }

        public async Task<Caixa?> GetOneById(Guid id)
        {
            try
            {
                return await _context.Set<Caixa>()
                    .SingleOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar caixa: {ex.Message}");
            }
        }

        public async Task<Caixa?> Create(CaixaDto dto)
        {
            try
            {
                var caixa = new Caixa
                {
                    Id = Guid.NewGuid(),
                    DataHoraAbertura = dto.DataHoraAbertura,
                    DataHoraFechamento = dto.DataHoraFechamento,
                    ValorInicial = (decimal)dto.ValorInicial,
                    ValorFinal = dto.ValorFinal.HasValue ? (decimal)dto.ValorFinal.Value : null,

                    TotalTransacoes = dto.TotalTransacoes,
                    Status = dto.Status,
                    FuncionarioNome = dto.FuncionarioNome,
                    Observacoes = dto.Observacoes
                };

                await _context.Set<Caixa>().AddAsync(caixa);
                await _context.SaveChangesAsync();

                return caixa;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao criar caixa: {ex.Message}");
            }
        }

        public async Task<Caixa?> Update(Guid id, CaixaDto dto)
        {
            try
            {
                var caixa = await GetOneById(id);

                if (caixa is null)
                    return null;

                caixa.DataHoraAbertura = dto.DataHoraAbertura;
                caixa.DataHoraFechamento = dto.DataHoraFechamento;
                caixa.ValorInicial = dto.ValorInicial;
                caixa.ValorFinal = dto.ValorFinal;
                caixa.TotalTransacoes = dto.TotalTransacoes;
                caixa.Status = dto.Status;
                caixa.FuncionarioNome = dto.FuncionarioNome;
                caixa.Observacoes = dto.Observacoes;

                _context.Set<Caixa>().Update(caixa);
                await _context.SaveChangesAsync();

                return caixa;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar caixa: {ex.Message}");
            }
        }

        public async Task<Caixa?> Delete(Guid id)
        {
            try
            {
                var caixa = await GetOneById(id);

                if (caixa is null)
                    return null;

                _context.Set<Caixa>().Remove(caixa);
                await _context.SaveChangesAsync();

                return caixa;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Erro ao deletar caixa: {ex.InnerException?.Message}");
                return null;
            }
        }

        private async Task<bool> Exists(Guid id)
        {
            return await _context.Set<Caixa>().AnyAsync(c => c.Id == id);
        }
    }
}
