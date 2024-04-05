using FoodAPP.Server.OpenAi;
using Microsoft.Extensions.Options;
using OpenAI_API;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace FoodAPP.Server.Services
{
    public class OpenAiService : IOpenAiService
    {
        private readonly OpenAiConfig config;
        public OpenAiService(IOptionsMonitor<OpenAiConfig> options)
        {
            config = options.CurrentValue;
        }

        public async Task<string> Drinks()
        {
            string text = "Full history of Rome";
            var api = new OpenAIAPI(config.key);
            var result = await api.Completions.GetCompletion(text);
            

            return result;
        }
    }
}
