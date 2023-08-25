namespace MyRDLC
{
    public interface IEmailService
    {
        Task<bool> SendAsync(string subject, string body, string to);
    }

    public class EmailService : IEmailService
    {
        Task<bool> IEmailService.SendAsync(string subject, string body, string to)
        {
            Console.WriteLine($"{subject} was sent.");
            return Task.FromResult(true);
        }
    }
}
