using Claustromania.Data;
using Claustromania.Mappings;
using Claustromania.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar conexão com o banco de dados
var connectionString = builder.Configuration.GetConnectionString("default");

builder.Services.AddDbContext<ClaustromaniaDbContext>(options =>
    options
        .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
        .UseSnakeCaseNamingConvention()
);

// Injeção de dependência dos serviços
builder.Services.AddScoped<FuncionarioService>();
builder.Services.AddScoped<EnderecoService>();
builder.Services.AddScoped<UnidadeService>();
builder.Services.AddScoped<SalaService>();
builder.Services.AddScoped<JogoService>();
builder.Services.AddScoped<CaixaService>();
builder.Services.AddScoped<TransacaoService>();
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<ReservaService>();
builder.Services.AddScoped<SalaJogoService>();

// (Opcional) Permitir requisições CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();

// Pipeline da aplicação
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("AllowAll");

app.MapControllers();
app.Run();
