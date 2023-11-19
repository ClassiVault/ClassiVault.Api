namespace ClassiVault.Api.DataAccess;

using ClassiVault.Api.DataAccess.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : IdentityDbContext<User>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Vault> Vaults { get; set; }
    public DbSet<EncryptionKeyInfo> EncryptionKeyInfos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure the primary keys
        modelBuilder.Entity<Vault>().HasKey(pv => pv.Id);
        modelBuilder.Entity<EncryptionKeyInfo>().HasKey(eki => eki.Id);

        // Configure the foreign key relationships
        modelBuilder.Entity<Vault>()
            .HasOne<User>(pv => pv.User)
            .WithMany(u => u.Vaults)
            .HasForeignKey(pv => pv.UserId);

        modelBuilder.Entity<EncryptionKeyInfo>()
            .HasOne<User>(eki => eki.User)
            .WithMany(u => u.EncryptionKeyInfos)
            .HasForeignKey(eki => eki.UserId);
    }
}