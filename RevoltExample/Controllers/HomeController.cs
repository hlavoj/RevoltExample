using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RevoltExample.Models;

namespace RevoltExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IActivityService _activityService;

        public HomeController(ILogger<HomeController> logger, IActivityService activityService)
        {
            _logger = logger;
            _activityService = activityService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("newpage/{idOne}/{idTwo}")]
        public async Task<IActionResult> Test(string idOne, string idTwo)
        {
            try
            {
                await _activityService.RecordActivity(idOne, idTwo);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return View(new UserIdentificator { WordOne = idOne, WordTwo = idTwo });
        }
    }
}
