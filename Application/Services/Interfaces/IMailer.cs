namespace Application.Services.Interfaces
{
    public interface IMailer
    {
        void SendMail(string subject, string body, int id);
    }
}