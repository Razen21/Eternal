FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Server/Eternal.Server.Host/Eternal.Server.Host.csproj", "Server/Eternal.Server.Host/"]
RUN dotnet restore "Server/Eternal.Server.Host/Eternal.Server.Host.csproj"
COPY . .
WORKDIR "/src/Server/Eternal.Server.Host"
RUN dotnet build "Eternal.Server.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Eternal.Server.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Eternal.Server.Host.dll"]
