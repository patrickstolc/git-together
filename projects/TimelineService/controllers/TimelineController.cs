using Microsoft.AspNetCore.Mvc;
using TimelineService.core;
using TimelineService.core.dtos;

namespace TimelineService.controllers;

[ApiController]
[Route("api/[controller]")]
public class TimelineController : ControllerBase
{
    private readonly TimelineRepo _timelineRepo;

    public TimelineController(TimelineRepo timelineRepo)
    {
        _timelineRepo = timelineRepo;
    }

    [HttpGet]
    [Route("GetTimelineById/{id}")]
    public async Task<IActionResult> GetTimelineById([FromRoute] int id)
    {
        try
        {
            return Ok(await _timelineRepo.GetTimelineById(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.ToString());
        }
    }
    
    [HttpPut]
    [Route("AddToBlackList")]
    public async Task<IActionResult> AddToBlackList([FromBody] AddToListDTO dto)
    {
        try
        {
            await _timelineRepo.AddToBlackList(dto);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.ToString());
        }
    }
    
    [HttpPut]
    [Route("AddToWhiteList")]
    public async Task<IActionResult> AddToWhiteList([FromBody] AddToListDTO dto)
    {
        try
        {
            await _timelineRepo.AddToWhiteList(dto);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.ToString());
        }
    }
}