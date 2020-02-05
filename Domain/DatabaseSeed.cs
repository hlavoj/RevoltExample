using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public interface IDatabaseSeed
    {
        Task Seed();
    }

    public class DatabaseSeed : IDatabaseSeed
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;

        public DatabaseSeed(UserManager<User> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task Seed()
        {
            await _context.Database.MigrateAsync().ConfigureAwait(false);

            if (!await _context.Users.AnyAsync())
            {

                string pass = "Test123*";
                var user = new User {UserName = "hlavoj+revoltuser@gmail.com", Email = "hlavoj+revoltuser@gmail.com"};
                var admin = new User {UserName = "hlavoj+revoltadmin@gmail.com", Email = "hlavoj+revoltadmin@gmail.com"};

                var a = await _userManager.CreateAsync(user, pass);
                var b = await _userManager.CreateAsync(admin, pass);
            }
        }
    }
}
