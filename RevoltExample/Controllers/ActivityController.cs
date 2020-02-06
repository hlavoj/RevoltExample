using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RevoltExample.Controllers
{
    [Route("api")]
    [ApiController]
    public class ActivityController : ControllerBase
    {

        private readonly IUserWordGenerationService _generationService;

        public ActivityController(IUserWordGenerationService generationService)
        {
            _generationService = generationService;
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



    }
}