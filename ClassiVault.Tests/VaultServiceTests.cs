namespace ClassiVault.Tests;

using System.Collections.Generic;
using Moq;
using ClassiVault.Api.DataAccess.Models;
using ClassiVault.Api.DataAccess.Services;

public class VaultServiceTests
{
    private readonly Mock<IVaultService> _mockService;

    public VaultServiceTests()
    {
        _mockService = new Mock<IVaultService>();
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnList()
    {
        // Arrange
        var passwordVaults = new List<Vault>
        {
            new Vault(),
            new Vault()
        };
        _mockService.Setup(service => service.GetAllAsync()).ReturnsAsync(passwordVaults);

        // Act
        var result = await _mockService.Object.GetAllAsync();

        // Assert
        Assert.Equal(passwordVaults, result);
    }

    [Fact]
    public async Task GetOneAsync_ShouldReturnPasswordVault()
    {
        // Arrange
        var passwordVault = new Vault();
        _mockService.Setup(service => service.GetOneAsync(It.IsAny<long>())).ReturnsAsync(passwordVault);

        // Act
        var result = await _mockService.Object.GetOneAsync(1);

        // Assert
        Assert.Equal(passwordVault, result);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnPasswordVault()
    {
        // Arrange
        var passwordVault = new Vault();
        _mockService.Setup(service => service.AddAsync(It.IsAny<Vault>())).ReturnsAsync(passwordVault);

        // Act
        var result = await _mockService.Object.AddAsync(new Vault());

        // Assert
        Assert.Equal(passwordVault, result);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnUpdatedPasswordVault()
    {
        // Arrange
        var passwordVault = new Vault();
        _mockService.Setup(service => service.UpdateAsync(It.IsAny<Vault>())).ReturnsAsync(passwordVault);

        // Act
        var result = await _mockService.Object.UpdateAsync(new Vault());

        // Assert
        Assert.Equal(passwordVault, result);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnWithoutError()
    {
        // Arrange
        _mockService.Setup(service => service.DeleteAsync(It.IsAny<long>())).Returns(Task.CompletedTask);

        // Act
        await _mockService.Object.DeleteAsync(1);

        // Assert
        _mockService.Verify(service => service.DeleteAsync(It.IsAny<long>()), Times.Once);
    }
}