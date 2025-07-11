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
            
            var pessoas = await _context.Pessoas.Include(p => p.Endereco) .ToListAsync();
            return _mapper.Map<IEnumerable<PessoaDto>>(pessoas);
        }

        public async Task<PessoaDto?> GetOneById(Guid id)
        {
            var pessoa = await _context.Pessoas.Include(p=>p.Endereco) .FirstOrDefaultAsync(p => p.Id == id);

            return pessoa is null ? null : _mapper.Map<PessoaDto>(pessoa);
        }

        public async Task<PessoaDto> Create(PessoaDto dto)
        {
            // 1. Mapear o DTO para o modelo Pessoa
            var pessoa = _mapper.Map<Pessoa>(dto);

            // 2. Gerar um novo GUID para a Pessoa
            pessoa.Id = Guid.NewGuid();

            // 3. Lidar com o Endereço
            // Se o EnderecoDto foi fornecido, o AutoMapper já deve ter mapeado para pessoa.Endereco.
            // Precisamos garantir que o ID do Endereço seja gerado se for um novo endereço.
            if (pessoa.Endereco != null)
            {
                // Se o Endereco.Id for Guid.Empty (padrão) ou não for fornecido no DTO,
                // significa que é um novo endereço e precisamos gerar um ID para ele.
                if (pessoa.Endereco.Id == Guid.Empty)
                {
                    pessoa.Endereco.Id = Guid.NewGuid();
                }
                // O EF Core irá detectar que este Endereco é uma nova entidade
                // e irá inseri-lo antes de inserir a Pessoa,
                // e então associará o FkEndereco da Pessoa ao Id do Endereco recém-criado.
            }
            else
            {
                // Se o Endereco não for fornecido no DTO, certifique-se de que FkEndereco seja nulo
                pessoa.FkEndereco = null;
            }

            // 4. Adicionar a Pessoa (e o Endereco associado, se houver) ao contexto
            _context.Pessoas.Add(pessoa);

            // 5. Salvar as mudanças no banco de dados
            await _context.SaveChangesAsync();

            // 6. Mapear o modelo Pessoa de volta para PessoaDto para o retorno
            // Isso garantirá que o DTO retornado inclua o ID gerado para Pessoa e Endereco
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
