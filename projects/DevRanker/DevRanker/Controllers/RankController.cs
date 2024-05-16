using DevRanker.Model;
using DevRanker.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevRanker.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class RankController : ControllerBase
    {
        private IRankingService _rankingService;
        public RankController(IRankingService rankingService)
        {
            _rankingService = rankingService;
        }

        [HttpGet]
        public IActionResult GetRankedProfiles([FromBody]Profile profile)
        {
            try
            {
                var rankedProfiles = _rankingService.GetProfiles(profile);
                return Ok(rankedProfiles);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Cash dis biiiiish");
                Console.WriteLine(ex.Message);
                return BadRequest("You reckd us son.");
            }
        }
    }
}
