
namespace ClassiVault.Api.DataAccess.Models
{
  /// <summary>
  /// The EncryptionKeyInfo model represents key-related information for each user.
  /// This includes a unique identifier for the key, a reference to the user,
  /// and a hash of the encryption key used for password encryption.
  /// The key hash is stored for security purposes and does not expose the actual key.
  /// </summary>
  public class EncryptionKeyInfo
  {
      public long KeyID { get; set; }
      public string UserID { get; set; } // Foreign Key
      public string KeyHash { get; set; }
      public DateTime CreatedAt { get; set; }
      public DateTime UpdatedAt { get; set; }

      // Navigation property
      public User User { get; set; }

      public EncryptionKeyInfo()
      {
          UserID = string.Empty;
          KeyHash = string.Empty;
          User = null!;
      }
  }


}