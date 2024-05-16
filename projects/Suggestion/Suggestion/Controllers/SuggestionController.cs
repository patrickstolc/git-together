using Microsoft.AspNetCore.Mvc;
using Suggestion.Core.Services;

namespace Suggestion.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SuggestionController : ControllerBase
    {
        private IService _service;

        public SuggestionController(IService service)
        {
            _service = service;
        }


        [HttpPost]
        public async Task<ActionResult> AddSuggestion([FromBody] Core.Entiies.Suggestion suggestion)
        {

            try
            {
                await _service.CreateSuggestion(suggestion);
                return Ok();
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        public ActionResult GetSsuggestions()
        {
            try
            {
                _service.GetSuggestions();
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
