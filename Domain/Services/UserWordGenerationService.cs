using System;
using System.Threading.Tasks;
using Domain.Helpers;
using Microsoft.EntityFrameworkCore;
using RevoltExample.Controllers;

namespace Domain.Services
{
    public class UserWordGenerationService : IUserWordGenerationService
    {
        private readonly IWordGenerator _generator;
        private readonly ApplicationDbContext _context;

        public UserWordGenerationService(IWordGenerator generator, ApplicationDbContext context)
        {
            _generator = generator;
            _context = context;
        }

        private async Task<UniquePairWords> GetUniquePairWords()
        {
            for (int i = 0; i < 100; i++)
            {
                var word1 = _generator.GetRandomWord();
                var word2 = _generator.GetRandomWord();
                var notUnique = await _context.Users.AnyAsync(u => u.IdOne == word1 && u.IdTwo == word2);
                if (!notUnique)
                {
                    return new UniquePairWords
                    {
                        WordOne = word1,
                        WordTwo = word2,
                    };
                }
            }
            throw new Exception();
        }


        public async Task RegenerateWordsForUsers()
        {
            var users = await _context.Users.ToListAsync();
            foreach (var user in users)
            {
                var uniqueWords = await GetUniquePairWords();
                user.IdOne = uniqueWords.WordOne;
                user.IdTwo = uniqueWords.WordTwo;
            }

            await _context.SaveChangesAsync();
        }

    }
}
