using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClassiVault.Api.Models
{
    class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<User>(options) {
    }
}
