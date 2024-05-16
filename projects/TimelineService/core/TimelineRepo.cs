using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using TimelineService.core.dtos;

namespace TimelineService.core;

public class TimelineRepo
{
    private readonly TimelineDataContext _context;
    private readonly HttpClient _httpClient;

    public TimelineRepo(TimelineDataContext context)
    {
        _context = context;
        _httpClient = new HttpClient();
    }

    public async Task<Timeline> GetTimelineById(int userId)
    {
        var timeline = await _context.Timelines.FirstOrDefaultAsync(t => t.UserId == userId);
        if (timeline is null)
            throw new KeyNotFoundException("Could find the timeline");

        var response = await _httpClient.GetAsync("requestURL");
        if (response.IsSuccessStatusCode)
        {
            var suggestionsJson = await response.RequestMessage.Content.ReadAsStringAsync();
            var suggestions = JsonSerializer.Deserialize<List<int>>(suggestionsJson);
            timeline.Suggestions = suggestions;
        }

        return timeline;
    }

    public async Task AddToBlackList(AddToListDTO dto)
    {
        //Remove from suggestions
        var timeline = await GetTimelineById(dto.UserId);
        timeline.Suggestions.Remove(dto.ProfileId);
        
        //Add to black list
        var json = JsonSerializer.Serialize(dto);
        StringContent queryString = new StringContent(json);
        await _httpClient.PostAsync("requestURL",queryString);
    } 
    
    public async Task AddToWhiteList(AddToListDTO dto)
    {
        //Remove from suggestions
        var timeline = await GetTimelineById(dto.UserId);
        timeline.Suggestions.Remove(dto.ProfileId);
        
        //Add to white list
        var json = JsonSerializer.Serialize(dto);
        StringContent queryString = new StringContent(json);
        await _httpClient.PostAsync("requestURL",queryString);
    }
}