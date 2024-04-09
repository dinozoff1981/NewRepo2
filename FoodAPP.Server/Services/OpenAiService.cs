using System;
using System.Net.Http;
using System.Threading.Tasks;
using FoodAPP.Server.OpenAi;
using Microsoft.Extensions.Options;
using OpenAI_API;

namespace FoodAPP.Server.Services
{
    public class OpenAiService : IOpenAiService
    {
        private readonly OpenAiConfig _config;

        public OpenAiService(IOptionsMonitor<OpenAiConfig> options)
        {
            _config = options.CurrentValue;
        }

        public async Task<string> Foods()
        {
            string text = "List of Foods In Sweden";
            var api = new OpenAIAPI(_config.key);
            var result = await api.Completions.GetCompletion(text);
            return result;
        }

      
    }
}
