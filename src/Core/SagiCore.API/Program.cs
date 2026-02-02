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
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

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

    // Adiciona tratamento para erros de autenticação
    config.Events = new JwtBearerEvents
    {
        OnChallenge = context =>
        {
            // Impede a resposta padrão do middleware
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
            // Loga o erro de autenticação
            var logger = context.HttpContext.RequestServices
                .GetRequiredService<ILogger<Program>>();
            
            logger.LogWarning("Falha na autenticação: {Error}", context.Exception.Message);

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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SagiCore API v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();