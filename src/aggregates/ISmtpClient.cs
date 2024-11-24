

using System.Net;
using System.Net.Mail;

namespace WrapperPoc;

public interface ISmtpClient: IDisposable
{
    string Host { get; set; }
    int Port { get; set; }
    bool EnableSsl { get; set; }
    ICredentialsByHost Credentials { get; set; }
    Task SendMailAsync(MailMessage mail);
}
