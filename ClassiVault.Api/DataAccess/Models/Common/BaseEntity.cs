namespace ClassiVault.Api.DataAccess.Models;

public abstract class BaseEntity
{
  public DateTime CreatedAt { get; set; }
  public DateTime? UpdatedAt { get; set; }

  public BaseEntity() {
    CreatedAt = DateTime.UtcNow;
    UpdatedAt = null;
  }
}
