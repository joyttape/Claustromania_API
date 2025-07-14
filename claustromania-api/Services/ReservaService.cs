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
            return await _context.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.SalaJogo)
                .ToListAsync();
        }

        public async Task<Reserva?> GetByIdAsync(Guid id)
        {
            return await _context.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.SalaJogo)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Reserva> CreateAsync(Reserva reserva)
        {
            if (!await _context.Clientes.AnyAsync(c => c.Id == reserva.FkCliente))
                throw new ArgumentException("Cliente não encontrado");

            if (!await _context.SalaJogos.AnyAsync(sj => sj.Id == reserva.FkSalaJogo))
                throw new ArgumentException("Sala de Jogo não encontrada");

            var conflito = await _context.Reservas
                .AnyAsync(r => r.FkSalaJogo == reserva.FkSalaJogo &&
                             r.DataReserva == reserva.DataReserva &&
                             r.HoraReserva == reserva.HoraReserva &&
                             r.Status != "cancelado");

            if (conflito)
                throw new ArgumentException("Já existe uma reserva para esta sala no horário selecionado");

            reserva.Id = Guid.NewGuid();
            reserva.Status = "reservado"; 

            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();
            return reserva;
        }

        public async Task<bool> UpdateAsync(Reserva reserva)
        {
            var existing = await _context.Reservas.FindAsync(reserva.Id);
            if (existing == null) return false;

            if (!await _context.Clientes.AnyAsync(c => c.Id == reserva.FkCliente))
                throw new ArgumentException("Cliente não encontrado");

            if (!await _context.SalaJogos.AnyAsync(sj => sj.Id == reserva.FkSalaJogo))
                throw new ArgumentException("Sala de Jogo não encontrada");

            existing.DataReserva = reserva.DataReserva;
            existing.HoraReserva = reserva.HoraReserva;
            existing.NumeroJogadores = reserva.NumeroJogadores;
            existing.ValorTotal = reserva.ValorTotal;
            existing.Status = reserva.Status;
            existing.Observacoes = reserva.Observacoes;
            existing.FormaPagamento = reserva.FormaPagamento;
            existing.FkCliente = reserva.FkCliente;
            existing.FkSalaJogo = reserva.FkSalaJogo;

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