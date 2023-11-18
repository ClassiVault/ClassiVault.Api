using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    var passwordVault = await _context.Vaults.FirstOrDefaultAsync(pv => pv.Id == id);
    return passwordVault;
  }

  public async Task<Vault> AddAsync(Vault passwordVault)
  {
    _context.Vaults.Add(passwordVault);
    await _context.SaveChangesAsync();
    return passwordVault;
  }

  public async Task<Vault> UpdateAsync(Vault passwordVault)
  {
    _context.Vaults.Update(passwordVault);
    await _context.SaveChangesAsync();
    return passwordVault;
  }

  public async Task DeleteAsync(long id)
  {
    var passwordVault = await _context.Vaults.FirstOrDefaultAsync(pv => pv.Id == id);
    if (passwordVault != null)
    {
      _context.Vaults.Remove(passwordVault);
      await _context.SaveChangesAsync();
    }
  }
}