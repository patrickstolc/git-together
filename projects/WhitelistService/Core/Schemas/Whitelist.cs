namespace WhitelistService.Core.Schemas;

public class AddProfileResponseData
{
    
}

public class AddProfileRequestData
{
    public int UserId { get; set; }
    public int ProfileId { get; set; }
}

public class GetProfileResponseData
{
    public int UserId { get; set; }
    public int[] ProfileIds { get; set; }
}