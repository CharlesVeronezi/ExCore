using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SagiCore.API.Filters;
using SagiCore.Auth.Application.UseCases;
using SagiCore.Auth.Infrastructure.Security;
using SagiCore.Cadastros.Application;
using SagiCore.Cadastros.Infrastructure;
using SagiCore.Communication.Responses;
using SagiCore.Shared.Application;
using SagiCore.Shared.Infrastructure;
using SagiCore.Shared.Infrastructure.Logging;
using Serilog;
using System.Text;
using System.Text.Json;

// Bootstrap logger para capturar erros durante a inicialização
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .CreateBootstrapLogger();  

try
{
    Log.Information("Iniciando SagiCore API...");

    var builder = WebApplication.CreateBuilder(args);

    // 1. Conectar Serilog ao Host
    builder.Host.UseSagiCoreSerilog();

    var secretKey = builder.Configuration["Jwt:SecretKey"]
        ?? throw new ArgumentException("Jwt:SecretKey não configurado");

    builder.Services.AddAuthentication(config =>
    {
        config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(config =>
    {
        config.RequireHttpsMetadata = false;
        config.SaveToken = true;
        config.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        };

        config.Events = new JwtBearerEvents
        {
            OnChallenge = context =>
            {
                context.HandleResponse();

                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.ContentType = "application/json";

                var response = ApiResponse<object>.Fail(
                    message: "Token de autenticação não fornecido ou inválido",
                    status: 401
                );

                var jsonResponse = JsonSerializer.Serialize(response, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                return context.Response.WriteAsync(jsonResponse);
            },
            OnAuthenticationFailed = context =>
            {
                Log.Warning("Falha na autenticação: {Error} | IP: {IP}",
                    context.Exception.Message,
                    context.HttpContext.Connection.RemoteIpAddress);

                return Task.CompletedTask;
            }
        };
    });

    builder.Services.AddScoped<TokenProvider>();
    builder.Services.AddScoped<LoginUseCase>();
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddSharedInfrastructure(builder.Configuration);

    // Shared
    builder.Services.AddSharedApplication();

    // Modulos - Cadastros
    builder.Services.AddCadastrosApplication();
    builder.Services.AddCadastrosInfrastructure(builder.Configuration);

    // Exception Filter
    builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

    var app = builder.Build();

    // Swagger settings
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "SagiCore API v1");
        });
    }

    app.UseHttpsRedirection();

    // 2. Middlewares de Autenticação
    app.UseAuthentication();
    app.UseAuthorization();

    app.UseSagiCoreRequestLogging(); 

    app.MapControllers();

    Log.Information("SagiCore API iniciada com sucesso!");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Aplicação falhou ao iniciar");
    throw;
}
finally
{
    Log.CloseAndFlush();
}