

using System.Net;
using System.Net.Mail;

namespace WrapperPoc;

public class SmtpClientWrapper : ISmtpClient
{
    private readonly SmtpClient _smtpClient;

    public SmtpClientWrapper()
    {
        _smtpClient = new SmtpClient();
    }

    public string Host
    {
        get => _smtpClient.Host ?? "";
        set => _smtpClient.Host = value;
    }

    public int Port
    {
        get => _smtpClient.Port;
        set => _smtpClient.Port = value;
    }

    public bool EnableSsl
    {
        get => _smtpClient.EnableSsl;
        set => _smtpClient.EnableSsl = value;
    }

    public ICredentialsByHost Credentials
    {
        get => _smtpClient.Credentials;
        set => _smtpClient.Credentials = value;
    }

    public Task SendMailAsync(MailMessage mail)
    {
        return _smtpClient.SendMailAsync(mail);
    }

    public void Dispose()
    {
        _smtpClient.Dispose();
    }
}
