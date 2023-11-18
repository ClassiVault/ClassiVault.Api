using Microsoft.EntityFrameworkCore;
using ClassiVault.Api.DataAccess;
using ClassiVault.Api.DataAccess.Models;

public class EncryptionKeyInfoService : IEncryptionKeyInfoService
{
    private readonly AppDbContext _context;

    public EncryptionKeyInfoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<EncryptionKeyInfo>> GetAllAsync()
    {
        return await _context.EncryptionKeyInfos.ToListAsync();
    }

    public async Task<EncryptionKeyInfo?> GetOneAsync(long id)
    {
      var encryptionKeyInfos = await _context.EncryptionKeyInfos.FirstOrDefaultAsync(eki => eki.Id == id);
      return encryptionKeyInfos;
    }

    public async Task<EncryptionKeyInfo> AddAsync(EncryptionKeyInfo encryptionKeyInfo)
    {
      _context.EncryptionKeyInfos.Add(encryptionKeyInfo);
      await _context.SaveChangesAsync();
      return encryptionKeyInfo;
    }

    public async Task<EncryptionKeyInfo> UpdateAsync(EncryptionKeyInfo encryptionKeyInfo)
    {
        _context.EncryptionKeyInfos.Update(encryptionKeyInfo);
        await _context.SaveChangesAsync();
        return encryptionKeyInfo;
    }

    public async Task DeleteAsync(long id)
    {
        var encryptionKeyInfo = await _context.EncryptionKeyInfos.FirstOrDefaultAsync(eki => eki.Id == id);
        if (encryptionKeyInfo != null)
        {
            _context.EncryptionKeyInfos.Remove(encryptionKeyInfo);
            await _context.SaveChangesAsync();
        }
    }
}