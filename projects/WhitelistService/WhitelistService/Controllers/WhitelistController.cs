using Microsoft.AspNetCore.Mvc;
using WhitelistService.Core.Common;
using WhitelistService.Core.Schemas;

namespace WhitelistService.Controllers;

[ApiController]
[Route("[controller]")]
public class WhitelistController : ControllerBase
{
    [HttpPost]
    public Task<Response<AddProfileResponseData>> AddProfileToWhitelist([FromBody]AddProfileRequestData request)
    {
        // Add profile to whitelist
        return Task.FromResult(Response<AddProfileResponseData>.Ok(new AddProfileResponseData()));
    }
    
    [HttpGet("{userId:int}")]
    public Task<Response<GetProfileResponseData>> GetWhitelistedProfiles(int userId)
    {
        // Get whitelisted profiles
        return Task.FromResult(Response<GetProfileResponseData>.Ok(new GetProfileResponseData()));
    }
}