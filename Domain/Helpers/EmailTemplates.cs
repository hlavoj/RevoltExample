using System.IO;
using System.Linq;
using System.Reflection;

namespace Domain.Helpers
{
    public class EmailTemplates : IEmailTemplates
    {


        public string GetTestEmail(string recipientName, string link)
        {
            string testEmailTemplate = ReadPhysicalFile("Helpers/Templates/TestEmail.template");

            string emailMessage = testEmailTemplate
                .Replace("{user}", recipientName)
                .Replace("{link}", link);

            return emailMessage;
        }


        private static string ReadPhysicalFile(string path)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string resourceName = assembly.GetManifestResourceNames()
                .Single(str => str.EndsWith("EmailTemplate.template"));

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();
                return result;
            }
        }
    }
}
