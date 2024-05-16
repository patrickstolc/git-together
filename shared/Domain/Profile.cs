namespace Domain;

public class Profile {
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Stack> TechStack { get; set; }
    public bool RemoteWork { get; set; }
    public int Age { get; set; }
    public string? Location { get; set; }
    public int LikeCount { get; set; }
}
