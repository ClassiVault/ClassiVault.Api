namespace ClassiVault.Api.DataAccess.Services;

using ClassiVault.Api.DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using Serilog;

public class IdentityEmailSenderService : IEmailSender<User>
{
    public Task SendConfirmationLinkAsync(User user, string email, string confirmationLink)
    {
        // TODO: Send the email using your favorite email service
        // Log the ConfirmationLink to the console for testing purposes
        Log.Information("ConfirmationLink: {confirmationLink}, Email: {email}, UserId: {userId}", confirmationLink, email, user.Id);

        return Task.CompletedTask;
    }

    public Task SendPasswordResetCodeAsync(User user, string email, string resetCode)
    {
        // TODO: Send the email using your favorite email service
        // Log the PasswordResetCode to the console for testing purposes
        Log.Information("PasswordResetCode: {confirmationLink}, Email: {email}, UserId: {userId}", resetCode, email, user.Id);

        return Task.CompletedTask;
    }

    public Task SendPasswordResetLinkAsync(User user, string email, string resetLink)
    {
        // TODO: Send the email using your favorite email service
        // Log the PasswordResetLink to the console for testing purposes
        Log.Information("PasswordResetLink: {confirmationLink}, Email: {email}, UserId: {userId}", resetLink, email, user.Id);

        return Task.CompletedTask;
    }
}