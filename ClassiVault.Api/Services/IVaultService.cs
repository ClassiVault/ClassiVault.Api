namespace ClassiVault.Api.DataAccess.Services;

using ClassiVault.Api.DataAccess.Models;

public interface IVaultService
{
  Task<List<Vault>> GetAllAsync();
  Task<Vault?> GetOneAsync(long id);
  Task<Vault> AddAsync(Vault vault);
  Task<Vault> UpdateAsync(Vault vault);
  Task DeleteAsync(long id);
}