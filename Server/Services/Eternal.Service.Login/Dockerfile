FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Server/Services/Eternal.Service.Login/Eternal.Service.Login.csproj", "Server/Services/Eternal.Service.Login/"]
RUN dotnet restore "Server/Services/Eternal.Service.Login/Eternal.Service.Login.csproj"
COPY . .
WORKDIR "/src/Server/Services/Eternal.Service.Login"
RUN dotnet build "Eternal.Service.Login.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Eternal.Service.Login.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Eternal.Service.Login.dll"]
