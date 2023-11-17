using ClassiVault.Api.DataAccess.Models;

public interface IEncryptionKeyInfoService
{
    Task<List<EncryptionKeyInfo>> GetAllAsync();
    Task<EncryptionKeyInfo?> GetOneAsync(long id);
    Task<EncryptionKeyInfo> AddAsync(EncryptionKeyInfo encryptionKeyInfo);
    Task<EncryptionKeyInfo> UpdateAsync(EncryptionKeyInfo encryptionKeyInfo);
    Task DeleteAsync(long id);
}