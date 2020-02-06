using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Domain.Services
{
    public class UserEmailService : IUserEmailService
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailTemplates _emailTemplates;
        private readonly IEmailSender _emailSender;

        public UserEmailService(ApplicationDbContext context, IEmailTemplates emailTemplates, IEmailSender emailSender)
        {
            _context = context;
            _emailTemplates = emailTemplates;
            _emailSender = emailSender;
        }


        public async Task SendMails()
        {
            var users = await _context.Users.ToListAsync();
            foreach (var user in users)
            {
                var message = _emailTemplates.GetTestEmail(user.UserName, $"http://localhost:44373/newpage/{user.IdOne}/{user.IdTwo}");
                await _emailSender.SendMail(user.Email, "test", message);
            }
        }
    }
}
