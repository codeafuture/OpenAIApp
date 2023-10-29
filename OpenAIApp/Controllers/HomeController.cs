using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;

namespace OpenAIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        [HttpGet]
        [Route("UseChatGPT")]
        public async Task<IActionResult> UseChatGPT(string input)
        {
            string output = "";
            var openai = new OpenAIAPI("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");

            CompletionRequest completionRequest = new CompletionRequest();
            completionRequest.Prompt = input;
            completionRequest.Model = OpenAI_API.Models.Model.DavinciText;
            completionRequest.MaxTokens = 1024;

            var completions = await openai.Completions.CreateCompletionAsync(completionRequest);

            foreach (var completion in completions.Completions)
            {
                output += completion.Text;
            }

            return Ok(output);
        }
    }
}
