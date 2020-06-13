#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src

COPY ["Academia.Store.API/Academia.Store.API.csproj", "src/Academia.Store.API/"]
RUN dotnet restore "src/Academia.Store.API/Academia.Store.API.csproj"

COPY . .

WORKDIR "/src/Academia.Store.API"
RUN dotnet build "Academia.Store.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Academia.Store.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Academia.Store.API.dll"]