# Utiliza la imagen base de ASP.NET Core 8.0
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Utiliza la imagen SDK de .NET 8.0 para la fase de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia el archivo de proyecto y restaura las dependencias
COPY ["TaskService/TaskService.csproj", "TaskService/"]
RUN dotnet restore "TaskService/TaskService.csproj"

# Copia el resto de los archivos y compila la aplicación
COPY . .
WORKDIR "/src/TaskService"
RUN dotnet build "TaskService.csproj" -c Release -o /app/build

# Publica la aplicación
FROM build AS publish
RUN dotnet publish "TaskService.csproj" -c Release -o /app/publish

# Crea la imagen final a partir de la imagen base
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskService.dll"]
