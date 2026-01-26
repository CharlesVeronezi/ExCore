FROM mcr.microsoft.com/dotnet/runtime:10.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
# Copiar csproj do Migrator e dos Módulos referenciados
COPY ["src/Tools/SagiCore.DbMigrator/SagiCore.DbMigrator.csproj", "src/Tools/SagiCore.DbMigrator/"]
COPY ["src/Modules/Cadastros/SagiCore.Cadastros.Infrastructure/SagiCore.Cadastros.Infrastructure.csproj", "src/Modules/Cadastros/SagiCore.Cadastros.Infrastructure/"]

RUN dotnet restore "./src/Tools/SagiCore.DbMigrator/SagiCore.DbMigrator.csproj"
COPY . .
WORKDIR "/src/src/Tools/SagiCore.DbMigrator"
RUN dotnet build "./SagiCore.DbMigrator.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SagiCore.DbMigrator.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SagiCore.DbMigrator.dll"]