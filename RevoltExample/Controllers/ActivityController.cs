using System;
using System.Threading.Tasks;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace RevoltExample.Controllers
{
    [Route("api")]
    [ApiController]
    public class ActivityController : ControllerBase
    {

        private readonly IUserWordGenerationService _generationService;
        private readonly IUserEmailService _emailService;

        public ActivityController(IUserWordGenerationService generationService, IUserEmailService emailService)
        {
            _generationService = generationService;
            _emailService = emailService;
        }

        [HttpGet("generate")]
        public async Task Generate()
        {
            try
            {
                await _generationService.RegenerateWordsForUsers();
            }
            catch (Exception e)
            {
                // should log this
                // return internal server error
                throw;
            }
        }

        [HttpGet("send")]
        public async Task Send()
        {
            try
            {
                await _emailService.SendMails();
            }
            catch (Exception e)
            {
                // should log this
                // return internal server error
                throw;
            }
        }



    }
}