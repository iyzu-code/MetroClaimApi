using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace MetroClaim.Api.Utilities;

public record EmailDto(string To, string Subject, string Body);

public interface IEmailHandler
{
    Task SendEmailAsync(EmailDto emailDto);
}

public class EmailHandler : IEmailHandler
{
    private readonly string _smtpServer;
    private readonly int _smtpPort;
    private readonly string _mailUsername;
    private readonly string _mailPassword;
    private readonly string _mailFrom;

    public EmailHandler(string smtpServer, int smptpPort, string mailUsername, string mailPassword, string mailFrom)
    {
        _smtpServer = smtpServer;
        _smtpPort = smptpPort;
        _mailUsername = mailUsername;
        _mailPassword = mailPassword;
        _mailFrom = mailFrom;
    }

    public async Task SendEmailAsync(EmailDto emailDto)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(_mailFrom));
        email.To.Add(MailboxAddress.Parse(emailDto.To));
        email.Subject = emailDto.Subject;
        email.Body = new TextPart(TextFormat.Html) { Text = emailDto.Body };

        using var smtp = new SmtpClient();
        await smtp.ConnectAsync(_smtpServer, _smtpPort, SecureSocketOptions.None);
        // await smtp.AuthenticateAsync(_mailUsername, _mailPassword);
        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);
    }
}