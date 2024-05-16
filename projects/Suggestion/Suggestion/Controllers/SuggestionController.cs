using Domain;
using Microsoft.AspNetCore.Mvc;
using SuggestionService.Core.Services;

namespace SuggestionService.Controllers
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
        public async Task<ActionResult> AddSuggestion([FromBody] Suggestion suggestion)
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
