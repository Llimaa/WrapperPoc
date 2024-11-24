using System.Net.Mail;
using Moq;

namespace WrapperPoc.Tests;

public class SmtpClientTest
{
    [Fact]
    public async Task When_SendEmailAsync_Should_Be_Verify_Properties_And_SendEmail_Method()
    {
        // Arrange
        var smtpClientMock = new Mock<ISmtpClient>();

        var mailMessage = new MailMessage("from@example.com", "to@example.com", "Subject", "Body");

        var emailService = new EmailService(smtpClientMock.Object);

        // Act
        await emailService.SendEmailAsync(mailMessage);

        // Assert
        smtpClientMock.VerifySet(smtp => smtp.Host = "smtp.example.com", Times.Once);
        smtpClientMock.VerifySet(smtp => smtp.Port = 587, Times.Once);
        smtpClientMock.VerifySet(smtp => smtp.EnableSsl = true, Times.Once);
        smtpClientMock.VerifySet(smtp => smtp.Credentials = It.IsAny<System.Net.NetworkCredential>(), Times.Once);

        smtpClientMock.Verify(smtp => smtp.SendMailAsync(mailMessage), Times.Once);
    }
}
