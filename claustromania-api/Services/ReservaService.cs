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
            return await _context.Reservas.ToListAsync();
        }

        public async Task<Reserva?> GetByIdAsync(Guid id)
        {
            return await _context.Reservas.FindAsync(id);
        }

        public async Task<Reserva> CreateAsync(Reserva reserva)
        {
            reserva.Id = Guid.NewGuid();
            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();
            return reserva;
        }

        public async Task<bool> UpdateAsync(Reserva reserva)
        {
            var existing = await _context.Reservas.FindAsync(reserva.Id);
            if (existing == null) return false;

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
