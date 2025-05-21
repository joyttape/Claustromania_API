using Claustromania.DataContexts;
using Claustromania.Dtos;
using Claustromania.Models;
using Microsoft.EntityFrameworkCore;


namespace Claustromania.Services
{
    public class FuncionarioService
    {

        private readonly AppDbContext _context;

        public FuncionarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Funcionario>> GetAll()
        {
            var list = await _context.Funcionario.ToListAsync();

            return list;
        }

        public async Task<Funcionario?> GetOneById(int id)
        {
            try
            {
                return await _context.Funcionario
                    .SingleOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Funcionario?> Create(FuncionarioDto func)
        {
            try
            {
                var cargo = func.Cargo;
                var salario = func.Salario;
                var data = func.data_contratacao;
                var turno = func.Turno;

                var newFunc = new Funcionario

                {
                    Cargo = func.Cargo,
                    Salario = func.Salario,
                    data_contratacao = func.data_contratacao,
                    Turno = func.Turno
                };

                await _context.Funcionario.AddAsync(newFunc);
                await _context.SaveChangesAsync();

                return newFunc;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Funcionario?> Update(int id, FuncionarioDto func)
        {
            try
            {
                var _func = await GetOneById(id);

                if (_func is null)
                {
                    return _func;
                }

                _func.Turno = func.Turno;
                _func.Cargo = func.Cargo;
                _func.Salario = func.Salario;
                _func.data_contratacao = func.data_contratacao;

                _context.Funcionario.Update(_func);
                await _context.SaveChangesAsync();

                return _func;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<Funcionario?> Delete(int id)
        {
            try
            {
                var func = await _context.Funcionario.FindAsync(id);

                if (func == null)
                    return null;

                _context.Funcionario.Remove(func);
                await _context.SaveChangesAsync();
                return func;

            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Erro ao deletar sala: {ex.InnerException?.Message}");
                return null;
            }
        }


        private async Task<bool> Exist(int id)
        {
            return await _context.Funcionario.AnyAsync(c => c.Id == id);
        }
    }
}
