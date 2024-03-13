#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5007

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["GrupoMaxima.Web/GrupoMaxima.Web.csproj", "GrupoMaxima.Web/"]
RUN dotnet restore "./GrupoMaxima.Web/GrupoMaxima.Web.csproj"
COPY . .
WORKDIR "/src/GrupoMaxima.Web"
RUN dotnet build "./GrupoMaxima.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./GrupoMaxima.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GrupoMaxima.Web.dll"]