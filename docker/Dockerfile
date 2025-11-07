# Use a imagem SDK do .NET 8.0 como base para build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar os arquivos de projeto e restaurar dependências
COPY ["APIvoeAltoPipas/APIvoeAltoPipas.csproj", "APIvoeAltoPipas/"]
COPY ["VoeAltoPipas.Application/VoeAltoPipas.Application.csproj", "VoeAltoPipas.Application/"]
COPY ["VoeAltoPipas.Domain/VoeAltoPipas.Domain.csproj", "VoeAltoPipas.Domain/"]
COPY ["VoeAltoPipas.Infrastucture/VoeAltoPipas.Infrastucture.csproj", "VoeAltoPipas.Infrastucture/"]
RUN dotnet restore "APIvoeAltoPipas/APIvoeAltoPipas.csproj"

# Copiar todo o código fonte
COPY . .

# Publicar a aplicação
RUN dotnet publish "APIvoeAltoPipas/APIvoeAltoPipas.csproj" -c Release -o /app/publish

# Imagem final
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
EXPOSE 443

ENTRYPOINT ["dotnet", "APIvoeAltoPipas.dll"]