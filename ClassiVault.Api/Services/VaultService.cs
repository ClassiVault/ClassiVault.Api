namespace ClassiVault.Api.DataAccess.Services;

using Microsoft.EntityFrameworkCore;
using ClassiVault.Api.DataAccess;
using ClassiVault.Api.DataAccess.Models;

public class VaultService : IVaultService
{
  private readonly AppDbContext _context;

  public VaultService(AppDbContext context)
  {
    _context = context;
  }

  public async Task<List<Vault>> GetAllAsync()
  {
    return await _context.Vaults.ToListAsync();
  }

  public async Task<Vault?> GetOneAsync(long id)
  {
    var vault = await _context.Vaults.FirstOrDefaultAsync(pv => pv.Id == id);
    return vault;
  }

  public async Task<Vault> AddAsync(Vault vault)
  {
    _context.Vaults.Add(vault);
    await _context.SaveChangesAsync();
    return vault;
  }

  public async Task<Vault> UpdateAsync(Vault vault)
  {
    _context.Vaults.Update(vault);
    await _context.SaveChangesAsync();
    return vault;
  }

  public async Task DeleteAsync(long id)
  {
    var vault = await _context.Vaults.FirstOrDefaultAsync(pv => pv.Id == id);
    if (vault != null)
    {
      _context.Vaults.Remove(vault);
      await _context.SaveChangesAsync();
    }
  }
}