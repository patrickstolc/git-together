using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Blacklist.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class BlackListController : ControllerBase
    {
        [HttpPost]
        public IActionResult AddProfileToBlackDic(int profileID, int UserID)
        {
            if (!BlackDic.blackDic.ContainsKey(UserID))
            {
                Console.WriteLine($"User {UserID} does not have a blacklist creating a new one");
                BlackDic.blackDic.Add(UserID, new List<int>());
                Console.WriteLine($"BlackList created for {UserID}");
            }

            BlackDic.blackDic[UserID].Add(profileID);
            Console.WriteLine($"User: {UserID} is blacklisting this Profile {profileID}");
            return Ok();
        }

        [HttpGet]
        public IActionResult GetProfilesFromBlackDic(int UserID)
        { 
            Console.WriteLine($"Getting Blacklist for {UserID}");
            return Ok(BlackDic.blackDic.ContainsKey(UserID) ? BlackDic.blackDic[UserID] : new List<Guid>()); 
        }

        [HttpDelete]
        public IActionResult DeleteFromBlackDic(int profileID, int UserID)
        {
            if (BlackDic.blackDic.ContainsKey(UserID))
            {
                try
                {
                    Console.WriteLine($"Removing {profileID} from {UserID}'s blacklist");
                    BlackDic.blackDic[UserID].Remove(profileID);
                    return Ok();
                } catch (Exception ex)
                {
                    return BadRequest("Profile is not in the Black Dictionary");
                }
            }
            return BadRequest("The User does not exist in our Black Dictionary");
        }
    }
}
