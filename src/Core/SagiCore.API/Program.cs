using SagiCore.API.Filters;
using SagiCore.Cadastros.Application;
using SagiCore.Cadastros.Infrastructure;
using SagiCore.Cadastros.Infrastructure.Migrations;
using SagiCore.Shared.Application;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Shared
builder.Services.AddSharedApplication();

// Modulos - Cadastros
builder.Services.AddCadastrosApplication();
builder.Services.AddCadastrosInfrastructure(builder.Configuration);

// Exception Filter
builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    CadastrosModuleInitializer.Initialize(app.Services);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();