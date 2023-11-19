FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ClassiVault.Api.csproj ClassiVault.Api
WORKDIR /src/ClassiVault.Api
RUN dotnet restore ClassiVault.Api.csproj
COPY . .
RUN dotnet build ClassiVault.Api.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish ClassiVault.Api.csproj -c Release -o /app/publish

FROM runtime AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClassiVault.Api.dll"]
