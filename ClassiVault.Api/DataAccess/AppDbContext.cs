using ClassiVault.Api.DataAccess.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClassiVault.Api.DataAccess
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<PasswordVault> PasswordVaults { get; set; }
        public DbSet<EncryptionKeyInfo> EncryptionKeyInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the primary keys
            modelBuilder.Entity<PasswordVault>().HasKey(pv => pv.VaultID);
            modelBuilder.Entity<EncryptionKeyInfo>().HasKey(eki => eki.KeyID);

            // Configure the foreign key relationships
            modelBuilder.Entity<PasswordVault>()
                .HasOne<User>(pv => pv.User)
                .WithMany(u => u.PasswordVaults)
                .HasForeignKey(pv => pv.UserID);

            modelBuilder.Entity<EncryptionKeyInfo>()
                .HasOne<User>(eki => eki.User)
                .WithMany(u => u.EncryptionKeyInfos)
                .HasForeignKey(eki => eki.UserID);
        }
    }
}
