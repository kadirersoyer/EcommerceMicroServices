#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/CatalogService/CatalogService.Api/CatalogService.Api.csproj", "src/CatalogService/CatalogService.Api/"]
COPY ["src/CatalogService/CatalogService.Shared/CatalogService.Shared.csproj", "src/CatalogService/CatalogService.Shared/"]
COPY ["src/CatalogService/CatalogService.Business/CatalogService.Business.csproj", "src/CatalogService/CatalogService.Business/"]
COPY ["src/CatalogService/CatalogService.Infrastructure/CatalogService.Infrastructure.csproj", "src/CatalogService/CatalogService.Infrastructure/"]
RUN dotnet restore "src/CatalogService/CatalogService.Api/CatalogService.Api.csproj"
COPY . .
WORKDIR "/src/src/CatalogService/CatalogService.Api"
RUN dotnet build "CatalogService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CatalogService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CatalogService.Api.dll"]