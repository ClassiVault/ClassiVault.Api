namespace ClassiVault.Api.DataAccess.Models;

using Microsoft.AspNetCore.Identity;

public class User : IdentityUser {
    public ICollection<Vault> Vaults { get; set; }
    public ICollection<EncryptionKeyInfo> EncryptionKeyInfos { get; set; }

    public User() {
        Vaults = new List<Vault>();
        EncryptionKeyInfos = new List<EncryptionKeyInfo>();
    }
}