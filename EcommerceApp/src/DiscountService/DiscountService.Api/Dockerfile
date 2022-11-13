#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/DiscountService/DiscountService.Api/DiscountService.Api.csproj", "src/DiscountService/DiscountService.Api/"]
RUN dotnet restore "src/DiscountService/DiscountService.Api/DiscountService.Api.csproj"
COPY . .
WORKDIR "/src/src/DiscountService/DiscountService.Api"
RUN dotnet build "DiscountService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DiscountService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DiscountService.Api.dll"]