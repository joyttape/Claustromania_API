using Claustromania.DataContexts;
using Claustromania.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Config connection database
var connectionString = builder.Configuration.GetConnectionString("default");

builder.Services.AddDbContext<AppDbContext>(options => 
    options
    .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
    .UseSnakeCaseNamingConvention()
);

builder.Services.AddScoped<SalaService>();
builder.Services.AddScoped<UnidadeService>();
builder.Services.AddScoped<FuncionarioService>();
builder.Services.AddScoped<JogoService>();
builder.Services.AddScoped<EnderecoService>();
builder.Services.AddScoped<PessoaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
