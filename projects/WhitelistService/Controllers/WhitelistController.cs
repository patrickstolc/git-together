using Messages;
using Microsoft.AspNetCore.Mvc;
using WhitelistService.Core.Common;
using WhitelistService.Core.Schemas;

namespace WhitelistService.Controllers;

[ApiController]
[Route("[controller]")]
public class WhitelistController : ControllerBase
{
    private readonly MessageClient.MessageClient _messageClient;
    public WhitelistController(MessageClient.MessageClient messageClient)
    {
        _messageClient = messageClient;
    }
    
    [HttpPost]
    public Task<Response<AddProfileResponseData>> AddProfileToWhitelist([FromBody]AddProfileRequestData request)
    {
        // Create remove profile message
        RemoveProfileMessage message = new()
        {
            UserId = request.UserId,
            ProfileId = request.ProfileId
        };
        
        // Add profile to whitelist
        var response = Task.FromResult(Response<AddProfileResponseData>.Ok(new AddProfileResponseData()));
        if (response.Result.Success)
        {
            _messageClient.Send(
                new RemoveProfileMessage { UserId = request.UserId, ProfileId = request.ProfileId }, 
                Topics.Topics.RefreshSuggestionsTopic
            );
        }

        return response;
    }
    
    [HttpGet("{userId:int}")]
    public Task<Response<GetProfileResponseData>> GetWhitelistedProfiles(int userId)
    {
        // Get whitelisted profiles
        return Task.FromResult(Response<GetProfileResponseData>.Ok(new GetProfileResponseData()));
    }
}