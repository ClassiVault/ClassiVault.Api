using ClassiVault.Api.DataAccess.Models;

public interface IVaultService
{
  Task<List<Vault>> GetAllAsync();
  Task<Vault?> GetOneAsync(long id);
  Task<Vault> AddAsync(Vault passwordVault);
  Task<Vault> UpdateAsync(Vault passwordVault);
  Task DeleteAsync(long id);
}