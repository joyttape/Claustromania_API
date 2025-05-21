using Claustromania.DataContexts;
using Claustromania.Dtos;
using Claustromania.Models;
using Microsoft.EntityFrameworkCore;

namespace Claustromania.Services
{
    public class UnidadeService
    {
        private readonly AppDbContext _context;

        public UnidadeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Unidade>> GetAll()
        {
            return await _context.Unidade.ToListAsync();
        }

        public async Task<Unidade?> GetOneById(int id)
        {
            return await _context.Unidade
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Unidade?> Create(UnidadeDto unidadeDto)
        {



            var newUnidade = new Unidade
            {
                NomeUnidade = unidadeDto.NomeUnidade,
                Capacidade = unidadeDto.Capacidade,
                Horario_Func = unidadeDto.Horario_Func,
                Telefone = unidadeDto.Telefone,
                Status_uni = unidadeDto.Status
            };

            await _context.Unidade.AddAsync(newUnidade);
            await _context.SaveChangesAsync();

            return newUnidade;
        }

        public async Task<Unidade?> Update(int id, UnidadeDto unidadeDto)
        {
            var unidade = await GetOneById(id);

            if (unidade is null)
                return null;

            unidade.NomeUnidade = unidadeDto.NomeUnidade;
            unidade.Capacidade = unidadeDto.Capacidade;
            unidade.Horario_Func = unidadeDto.Horario_Func;
            unidade.Telefone = unidadeDto.Telefone;
            unidade.Status_uni = unidadeDto.Status;

            _context.Unidade.Update(unidade);
            await _context.SaveChangesAsync();

            return unidade;
        }

        public async Task<Unidade?> Delete(int id)
        {
            var unidade = await _context.Unidade.FindAsync(id);

            if (unidade == null)
                return null;

            _context.Unidade.Remove(unidade);
            await _context.SaveChangesAsync();
            return unidade;
        }

        private async Task<bool> Exist(int id)
        {
            return await _context.Unidade.AnyAsync(c => c.Id == id);
        }
    }
}
