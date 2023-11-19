# Use the .NET SDK image to build the solution
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy necessary files and restore dependencies
COPY ClassiVault.Api/ClassiVault.Api.csproj ClassiVault.Api/
COPY ClassiVault.Tests/ClassiVault.Tests.csproj ClassiVault.Tests/
RUN dotnet restore ClassiVault.Tests/ClassiVault.Tests.csproj

# Copy the rest of the solution files
COPY ClassiVault.Api/. ClassiVault.Api/
COPY ClassiVault.Tests/. ClassiVault.Tests/

# Build the Test project
RUN dotnet build ClassiVault.Tests/ClassiVault.Tests.csproj -c Release

# Set the working directory to the test project's directory
WORKDIR /src/ClassiVault.Tests

# Define the entry point for the container
ENTRYPOINT ["dotnet", "test", "--logger:trx"]
