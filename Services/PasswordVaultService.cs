using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClassiVault.Api.DataAccess;
using ClassiVault.Api.DataAccess.Models;

public class PasswordVaultService : IPasswordVaultService
{
  private readonly AppDbContext _context;

  public PasswordVaultService(AppDbContext context)
  {
    _context = context;
  }

  public async Task<List<PasswordVault>> GetAllAsync()
  {
    return await _context.PasswordVaults.ToListAsync();
  }

  public async Task<PasswordVault?> GetOneAsync(long id)
  {
    var passwordVault = await _context.PasswordVaults.FirstOrDefaultAsync(pv => pv.VaultID == id);
    return passwordVault;
  }

  public async Task<PasswordVault> AddAsync(PasswordVault passwordVault)
  {
    _context.PasswordVaults.Add(passwordVault);
    await _context.SaveChangesAsync();
    return passwordVault;
  }

  public async Task<PasswordVault> UpdateAsync(PasswordVault passwordVault)
  {
    _context.PasswordVaults.Update(passwordVault);
    await _context.SaveChangesAsync();
    return passwordVault;
  }

  public async Task DeleteAsync(long id)
  {
    var passwordVault = await _context.PasswordVaults.FirstOrDefaultAsync(pv => pv.VaultID == id);
    if (passwordVault != null)
    {
      _context.PasswordVaults.Remove(passwordVault);
      await _context.SaveChangesAsync();
    }
  }
}