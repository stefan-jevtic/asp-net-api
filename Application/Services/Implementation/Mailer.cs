using Application.Services.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;
using Repository.UnitOfWork;

namespace Application.Services.Implementation
{
    public class Mailer : IMailer
    {
        private readonly string HostMail = "stefan.jevtic.45.15@ict.edu.rs";
        private readonly string HostPassword = "<password>";
        private readonly string MailServer = "smtp.gmail.com";
        private readonly int MailPort = 587;
        private readonly bool secure = false;
        private MimeMessage _message;
        private readonly IUnitOfWork _unitOfWork;

        public Mailer(IUnitOfWork unitOfWork)
        {
            _message = new MimeMessage();
            _message.To.Add(new MailboxAddress(HostMail));
            _unitOfWork = unitOfWork;
        }
        public void SendMail(string subject, string body, int id)
        {
            var user = _unitOfWork.User.Get(id);
            _message.From.Add(new MailboxAddress(user.Email));
            _message.Subject = subject;
            _message.Body = new TextPart("plain")
            {
                Text = "Email sent from: " + user.Email + "\n\n" + body
            };
            using (var client = new SmtpClient())
            {
                client.Connect(MailServer, MailPort, secure);
                client.Authenticate(HostMail, HostPassword);
                client.Send(_message);
                client.Disconnect(true);
            }
        }
    }
}