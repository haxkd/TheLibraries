using System.Net.Mail;
using System.Net;


public class Mailer
{
    /*
    This class is use for to send a mail using SMTP server of any client.
    */
    public bool SendMail(string subject, string msg, string smtpHost, int smtpPort, string smtpUserName, string smtpPassword, bool enableSsl, string toEmail)
    {
        /*
        subject: subject of the mail.
        msg: msg for the mail body, it can contain html.
        smtpHost: host of SMTP server.
        smtpPort: SMPTP server port/
        smtpUserName: username for login that SMTP server.
        smtpPassword: password for login that SMTP server.
        enableSsl: SSL should enable or not.
        toEmail : to the email whome to send the mail.
        return : true means success, false means failed.
        */
        try
        {
            SmtpClient smtpClient = new SmtpClient(smtpHost, smtpPort);
            smtpClient.Credentials = new NetworkCredential(smtpUserName, smtpPassword);
            smtpClient.EnableSsl = enableSsl;
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(smtpUserName);
            mailMessage.To.Add(toEmail);
            mailMessage.Subject = subject;
            mailMessage.Body = msg;
            mailMessage.IsBodyHtml = true;
            smtpClient.Send(mailMessage);
        }
        catch{
            return false;
        }
        return true;
    }
}
