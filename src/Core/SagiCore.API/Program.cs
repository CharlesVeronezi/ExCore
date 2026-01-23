using SagiCore.API.Filters;
using SagiCore.Cadastros.Application;
using SagiCore.Cadastros.Infrastructure;
using SagiCore.Shared.Application;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Shared
builder.Services.AddSharedApplication();

// Modulos - Application
builder.Services.AddCadastrosApplication();

// Modulos - Infrastructure
builder.Services.AddCadastrosInfrastructure(builder.Configuration);

// Exception Filter
builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

builder.Services.AddAutoMapper(typeof(SagiCore.Cadastros.Application.Produtos.Mapping.ProdutoProfile).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();