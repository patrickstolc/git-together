namespace WhitelistService.Core.Entities;

public class Whitelist
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int[] WhitelistedProfileIds { get; set; }
}