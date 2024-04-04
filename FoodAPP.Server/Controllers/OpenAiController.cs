using FoodAPP.Server.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace FoodAPP.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OpenAiController : ControllerBase
    {
      

        private readonly ILogger<OpenAiController> _logger;
        private readonly IOpenAiService _openAiService;

        public OpenAiController(ILogger<OpenAiController> logger,IOpenAiService openAiService)
        {
            _logger = logger;
            _openAiService = openAiService;
        }
        [HttpPost]
        [Route("Drinks")]

        public async Task<IActionResult>Drinks()
        {
        
            var result=await _openAiService.Drinks();

            return Ok(result);
        }


       







    }
}
