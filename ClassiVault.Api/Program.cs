using ClassiVault.Api.DataAccess;
using ClassiVault.Api.DataAccess.Models;
using ClassiVault.Api.DataAccess.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorizationBuilder();
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("ClassiVaultDb"));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddScoped<IVaultService, VaultService>();
builder.Services.AddScoped<IEncryptionKeyInfoService, EncryptionKeyInfoService>();
builder.Services.AddSingleton<IEmailSender<User>, IdentityEmailSenderService>();

var app = builder.Build();

// app.UseHttpsRedirection();
app.MapControllers();
app.MapIdentityApi<User>();
app.UseRouting();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();