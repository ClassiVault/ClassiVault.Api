
namespace ClassiVault.Api.DataAccess.Models
{
  /// <summary>
  /// The PasswordVault model stores encrypted passwords and related information.
  /// Each entry includes a unique identifier, a reference to the user,
  /// the encrypted password, account identifier, and an optional website URL.
  /// Timestamps for creation and last update are also maintained.
  /// </summary>
  public class PasswordVault
  {
      public long VaultID { get; set; }
      public string UserID { get; set; } // Foreign Key
      public string EncryptedPassword { get; set; }
      public string AccountIdentifier { get; set; }
      public string WebsiteURL { get; set; }
      public DateTime CreatedAt { get; set; }
      public DateTime UpdatedAt { get; set; }

      // Navigation property
      public User User { get; set; }

      public PasswordVault()
      {
        UserID = string.Empty;
        EncryptedPassword = string.Empty;
        AccountIdentifier = string.Empty;
        WebsiteURL = string.Empty;
        User = null!;
      }

  }
}