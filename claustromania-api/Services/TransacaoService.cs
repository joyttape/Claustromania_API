using Claustromania.Data;
using Claustromania.DTOs;
using Claustromania.Models;
using Microsoft.EntityFrameworkCore;

namespace Claustromania.Services
{
    public class TransacaoService
    {
        private readonly ClaustromaniaDbContext _context;

        public TransacaoService(ClaustromaniaDbContext context)
        {
            _context = context;
        }

        public async Task<Transacao?> GetByIdAsync(Guid id)
        {
            return await _context.Transacoes
                .Include(t => t.Caixa)
                .Include(t => t.Pessoa)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<Transacao>> GetAllAsync()
        {
            return await _context.Transacoes
                .Include(t => t.Caixa)
                .Include(t => t.Pessoa)
                .ToListAsync();
        }

        public async Task<Transacao> CreateAsync(TransacaoDto dto)
        {
            // Validação básica do DTO
            if (dto == null)
                throw new ArgumentNullException(nameof(dto), "DTO não pode ser nulo");

            if (dto.FkCaixa == Guid.Empty)
                throw new ArgumentException("ID do caixa não pode ser vazio");

            // Verifica se o caixa existe e está aberto
            // Verifique apenas a propriedade que existe no seu modelo
            var caixa = await _context.Caixas
                .FirstOrDefaultAsync(c => c.Id == dto.FkCaixa &&
                                        (c.Status == "aberto"));

            if (caixa == null)
                throw new Exception("Caixa não encontrado ou está fechado");

            // Cria a transação
            var transacao = new Transacao
            {
                Id = Guid.NewGuid(),
                Valor = dto.Valor,
                Data = DateTime.TryParse(dto.Data, out var data) ? data : DateTime.Now,
                Tipo = !string.IsNullOrEmpty(dto.Tipo) ? dto.Tipo : "RESERVA",
                FormaPagamento = dto.FormaPagamento,
                Pagador = dto.Pagador,
                ValorRecebido = dto.ValorRecebido ?? dto.Valor,
                Troco = dto.Troco ?? 0,
                FkCaixa = dto.FkCaixa,
                FkPessoa = dto.FkPessoa,
                FkReserva = dto.FkReserva
            };

            _context.Transacoes.Add(transacao);
            await _context.SaveChangesAsync();

            return transacao;
        }


        public async Task<bool> UpdateAsync(Guid id, TransacaoDto dto)
        {
            var existing = await _context.Transacoes
                .FirstOrDefaultAsync(t => t.Id == id);

            if (existing == null)
                return false;

            var caixa = await _context.Caixas.FindAsync(dto.FkCaixa);
            if (caixa == null)
                throw new Exception("Caixa não encontrado");

            Pessoa? pessoa = null;
            if (dto.FkPessoa.HasValue)
            {
                pessoa = await _context.Pessoas.FindAsync(dto.FkPessoa.Value);
                if (pessoa == null)
                    throw new Exception("Pessoa não encontrada");
            }

            // Atribuições com tratamento correto da data
            existing.Valor = dto.Valor;
            existing.Data = DateTime.TryParse(dto.Data, out var parsedDate) ? parsedDate : DateTime.Now;
            existing.Tipo = dto.Tipo;
            existing.FormaPagamento = dto.FormaPagamento;
            existing.Pagador = dto.Pagador;
            existing.ValorRecebido = dto.ValorRecebido;
            existing.Troco = dto.Troco;
            existing.FkCaixa = dto.FkCaixa;
            existing.FkPessoa = dto.FkPessoa;
            existing.FkReserva = dto.FkReserva;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var transacao = await _context.Transacoes.FindAsync(id);
            if (transacao == null)
                return false;

            _context.Transacoes.Remove(transacao);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

