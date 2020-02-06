using System;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Services
{
    public class ActivityService : IActivityService
    {

        private readonly ApplicationDbContext _context;

        public ActivityService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task RecordActivity(string idOne, string idTwo)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.IdOne == idOne && u.IdTwo == idTwo);
            var userActivity = new UserActivity {DateOfAction = DateTime.Now, User = user};

            await _context.UserActivities.AddAsync(userActivity);
            await _context.SaveChangesAsync();
        }
    }
}
