using Microsoft.AspNetCore.Identity;

namespace ClassiVault.Api.DataAccess.Models
{
    public class User : IdentityUser {
        public ICollection<PasswordVault> PasswordVaults { get; set; }
        public ICollection<EncryptionKeyInfo> EncryptionKeyInfos { get; set; }

        public User() {
            PasswordVaults = new List<PasswordVault>();
            EncryptionKeyInfos = new List<EncryptionKeyInfo>();
        }
    }
}