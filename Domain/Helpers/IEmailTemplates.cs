namespace Domain.Helpers
{
    public interface IEmailTemplates
    {
        string GetTestEmail(string recipientName, string link);
    }
}