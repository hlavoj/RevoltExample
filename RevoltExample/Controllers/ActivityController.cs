using System;
using System.Threading.Tasks;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RevoltExample.Controllers
{
    [Route("api")]
    [ApiController]
    public class ActivityController : ControllerBase
    {

        private readonly IUserWordGenerationService _generationService;
        private readonly IUserEmailService _emailService;
        private readonly ILogger<ActivityController> _logger;


        public ActivityController(IUserWordGenerationService generationService, IUserEmailService emailService, ILogger<ActivityController> logger)
        {
            _generationService = generationService;
            _emailService = emailService;
            _logger = logger;
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
                _logger.LogError(e, "Unable to generate words to users.");
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
                _logger.LogError(e, "Unable to send emails to users.");
                throw;
            }
        }



    }
}