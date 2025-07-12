using Claustromania.Data;
using Claustromania.Models;
using Microsoft.EntityFrameworkCore;

namespace Claustromania.Services
{
    public class ReservaService
    {
        private readonly ClaustromaniaDbContext _context;

        public ReservaService(ClaustromaniaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Reserva>> GetAllAsync()
        {
            return await _context.Reservas.Include(r => r.Cliente).ThenInclude(c => c.Pessoa).ThenInclude(p => p.Endereco).ToListAsync();
        }

        public async Task<Reserva?> GetByIdAsync(Guid id)
        {
            return await _context.Reservas.Include(r => r.Cliente).ThenInclude(c => c.Pessoa).ThenInclude(p => p.Endereco).FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Reserva> CreateAsync(Reserva reserva)
        {
            // Validação: Verificar se o Cliente existe
            var clienteExiste = await _context.Clientes.AnyAsync(c => c.Id == reserva.FkCliente);
            if (!clienteExiste)
            {
                throw new ArgumentException("Cliente não encontrado.");
            }

            // Validação: Verificar se a SalaJogo existe
            var salaJogoExiste = await _context.SalaJogos.AnyAsync(sj => sj.Id == reserva.FkSalaJogo);
            if (!salaJogoExiste)
            {
                throw new ArgumentException("Sala de Jogo não encontrada.");
            }

            reserva.Id = Guid.NewGuid();
            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();
            return reserva;
        }

        public async Task<bool> UpdateAsync(Reserva reserva)
        {
            var existing = await _context.Reservas.FindAsync(reserva.Id);
            if (existing == null) return false;

            // Validação: Verificar se o Cliente existe
            var clienteExiste = await _context.Clientes.AnyAsync(c => c.Id == reserva.FkCliente);
            if (!clienteExiste)
            {
                throw new ArgumentException("Cliente não encontrado.");
            }

            // Validação: Verificar se a SalaJogo existe
            var salaJogoExiste = await _context.SalaJogos.AnyAsync(sj => sj.Id == reserva.FkSalaJogo);
            if (!salaJogoExiste)
            {
                throw new ArgumentException("Sala de Jogo não encontrada.");
            }

            _context.Entry(existing).CurrentValues.SetValues(reserva);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null) return false;

            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
