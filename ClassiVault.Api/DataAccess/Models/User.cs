using Microsoft.AspNetCore.Identity;

namespace ClassiVault.Api.DataAccess.Models
{
    public class User : IdentityUser {
        public ICollection<Vault> Vaults { get; set; }
        public ICollection<EncryptionKeyInfo> EncryptionKeyInfos { get; set; }

        public User() {
            Vaults = new List<Vault>();
            EncryptionKeyInfos = new List<EncryptionKeyInfo>();
        }
    }
}