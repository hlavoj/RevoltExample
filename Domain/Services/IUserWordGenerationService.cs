﻿using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IUserWordGenerationService
    {
        Task RegenerateWordsForUsers();
    }
}