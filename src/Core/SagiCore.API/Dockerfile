FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

# Criar diret�rio de logs com permiss�es adequadas
RUN mkdir -p /var/log/sagicore && chmod 777 /var/log/sagicore

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Vari�veis de ambiente para produ��o
ENV ASPNETCORE_ENVIRONMENT=Production
ENV DOTNET_RUNNING_IN_CONTAINER=true
ENV JWT_SECRET_KEY=QWE123ASD456ZXC789_002_CHAVE_SUPER_SECRETA_32_CHARS
ENV CONNECTION_AUTENTICA=Host=autentica_server;Port=5432;Database=autentica;Username=postgres;Password=postgres

ENTRYPOINT ["dotnet", "SagiCore.API.dll"]