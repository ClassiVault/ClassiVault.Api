using ClassiVault.Api.DataAccess.Models;

public interface IPasswordVaultService
{
  Task<List<PasswordVault>> GetAllAsync();
  Task<PasswordVault?> GetOneAsync(long id);
  Task<PasswordVault> AddAsync(PasswordVault passwordVault);
  Task<PasswordVault> UpdateAsync(PasswordVault passwordVault);
  Task DeleteAsync(long id);
}