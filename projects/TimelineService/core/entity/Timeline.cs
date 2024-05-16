namespace TimelineService;

public class Timeline
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public List<int> Suggestions { get; set; } = new();
    
}