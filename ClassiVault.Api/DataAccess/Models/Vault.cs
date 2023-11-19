
namespace ClassiVault.Api.DataAccess.Models;

/// <summary>
/// The Vault model stores encrypted passwords or senstitive information.
/// Each entry includes a unique identifier, a reference to the user,
/// the encrypted password, account identifier, and an optional website URL.
/// Timestamps for creation and last update are also maintained.
/// </summary>
public class Vault : BaseEntity
{
    public long Id { get; set; }
    public string UserId { get; set; } // Foreign Key
    public string EncryptedValue { get; set; }
    public string Identifier { get; set; }
    public string WebsiteUrl { get; set; }

    // Navigation property
    public User User { get; set; }

    public Vault() : base()
    {
      UserId = string.Empty;
      EncryptedValue = string.Empty;
      Identifier = string.Empty;
      WebsiteUrl = string.Empty;
      User = null!;
    }
}