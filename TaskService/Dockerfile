# Usa la imagen base de ASP.NET Core
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Usa la imagen SDK para construir el proyecto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["TaskService/TaskService.csproj", "TaskService/"]
RUN dotnet restore "TaskService/TaskService.csproj"
COPY . .
WORKDIR "/src/TaskService"
RUN dotnet build "TaskService.csproj" -c Release -o /app/build

# Publica la aplicación
FROM build AS publish
RUN dotnet publish "TaskService.csproj" -c Release -o /app/publish

# Crea la imagen final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskService.dll"]
