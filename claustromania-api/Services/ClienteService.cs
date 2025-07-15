using Claustromania.Data;
using Claustromania.Models;
using Microsoft.EntityFrameworkCore;

namespace Claustromania.Services
{
    public class ClienteService
    {

        private readonly ClaustromaniaDbContext _context;
        private readonly PessoaService _pessoaService;

        public ClienteService(ClaustromaniaDbContext context, PessoaService pessoaService)
        {
            _context = context;
            _pessoaService = pessoaService;
        }

        public async Task<List<Cliente>> GetAllAsync()
        {
            return await _context.Clientes.Include(c => c.Pessoa).ThenInclude(p => p.Endereco).ToListAsync();
        }

        public async Task<Cliente?> GetByIdAsync(Guid id)
        {
            return await _context.Clientes.Include(c => c.Pessoa).ThenInclude(p => p.Endereco).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Cliente?> GetByEmailAsync(string email)
        {
            return await _context.Clientes
                                 .Include(c => c.Pessoa)
                                 .ThenInclude(p => p.Endereco)
                                 .FirstOrDefaultAsync(c => c.Pessoa != null && c.Pessoa.Email == email);
        }

        public async Task<Cliente> CreateAsync(Cliente cliente)
        {
            
            if (cliente.Pessoa != null && !string.IsNullOrEmpty(cliente.Pessoa.Email))
            {
                var existingCliente = await _context.Clientes.Include(c => c.Pessoa).FirstOrDefaultAsync(c => c.Pessoa != null && c.Pessoa.Email == cliente.Pessoa.Email);
                if (existingCliente != null)
                {
                    throw new ArgumentException("Já existe um cliente cadastrado com este e-mail.");
                }
            }

            cliente.Id = Guid.NewGuid();
            if (cliente.Pessoa != null)
            {
                cliente.Pessoa.Id = Guid.NewGuid();
                if (cliente.Pessoa.Endereco != null)
                {
                    cliente.Pessoa.Endereco.Id = Guid.NewGuid(); 
                }
            }

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<bool> UpdateAsync(Cliente clienteAtualizado)
        {
            var clienteExistente = await _context.Clientes
                .Include(c => c.Pessoa)
                    .ThenInclude(p => p.Endereco)
                .FirstOrDefaultAsync(c => c.Id == clienteAtualizado.Id);

            if (clienteExistente == null)
                return false;

            
            clienteExistente.NivelExperiencia = clienteAtualizado.NivelExperiencia;

            if (clienteAtualizado.Pessoa != null)
            {
                if (clienteExistente.Pessoa == null)
                {
                    clienteExistente.Pessoa = clienteAtualizado.Pessoa;
                }
                else
                {
                    clienteExistente.Pessoa.Nome = clienteAtualizado.Pessoa.Nome;
                    clienteExistente.Pessoa.CPF = clienteAtualizado.Pessoa.CPF;
                    clienteExistente.Pessoa.DataNascimento = clienteAtualizado.Pessoa.DataNascimento;
                    clienteExistente.Pessoa.Sexo = clienteAtualizado.Pessoa.Sexo;
                    clienteExistente.Pessoa.Email = clienteAtualizado.Pessoa.Email;

                    if (clienteAtualizado.Pessoa.Endereco != null)
                    {
                        if (clienteExistente.Pessoa.Endereco == null)
                        {
                            clienteExistente.Pessoa.Endereco = clienteAtualizado.Pessoa.Endereco;
                        }
                        else
                        {
                            clienteExistente.Pessoa.Endereco.Logradouro = clienteAtualizado.Pessoa.Endereco.Logradouro;
                            clienteExistente.Pessoa.Endereco.Numero = clienteAtualizado.Pessoa.Endereco.Numero;
                            clienteExistente.Pessoa.Endereco.Complemento = clienteAtualizado.Pessoa.Endereco.Complemento;
                            clienteExistente.Pessoa.Endereco.Bairro = clienteAtualizado.Pessoa.Endereco.Bairro;
                            clienteExistente.Pessoa.Endereco.Cidade = clienteAtualizado.Pessoa.Endereco.Cidade;
                            clienteExistente.Pessoa.Endereco.Estado = clienteAtualizado.Pessoa.Endereco.Estado;
                            clienteExistente.Pessoa.Endereco.CEP = clienteAtualizado.Pessoa.Endereco.CEP;
                        }
                    }
                    else if (clienteExistente.Pessoa.Endereco != null)
                    {
                        _context.Entry(clienteExistente.Pessoa.Endereco).State = EntityState.Deleted;
                        clienteExistente.Pessoa.Endereco = null;
                    }
                }
            }
            else if (clienteExistente.Pessoa != null)
            {
                _context.Entry(clienteExistente.Pessoa).State = EntityState.Deleted;
                clienteExistente.Pessoa = null;
            }

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("ERRO AO SALVAR: " + ex.InnerException?.Message);
                return false;
            }
        }


        public async Task<IEnumerable<Cliente>> GetAllDetalhadoAsync()
        {
            return await _context.Clientes
                                 .Include(c => c.Pessoa)
                                 .ToListAsync();
        }

        public async Task<Cliente?> GetByIdDetalhadoAsync(Guid id)
        {
            return await _context.Clientes
                                 .Include(c => c.Pessoa) 
                                 .FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var cliente = await _context.Clientes
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cliente == null)
                return false;

            Guid pessoaId = cliente.FkPessoa;

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            await _pessoaService.Delete(pessoaId); 

            return true;
        }
    }
}