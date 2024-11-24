

using System.Net;
using System.Net.Mail;

namespace WrapperPoc;

public class EmailService
{
    private readonly ISmtpClient _smtpClient;

    public EmailService(ISmtpClient smtpClient) => 
        _smtpClient = smtpClient;

    public async Task SendEmailAsync(MailMessage mail)
    {
        using (_smtpClient)
        {
            _smtpClient.Host = "smtp.example.com";
            _smtpClient.Port = 587;
            _smtpClient.EnableSsl = true;
            _smtpClient.Credentials = new NetworkCredential("Username","Password");
            await _smtpClient.SendMailAsync(mail);
        }
    }
}
