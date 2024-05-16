namespace DevRanker.Model
{
    public class Profile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Stack> stack { get; set; }
        public bool RemoteWork { get; set; }
        public int Age { get; set; }
        public string? Location { get; set; }
        public int LikeCount { get; set; }

    }

    public enum Stack
    {
        PHPisMyLife,
        Dotnet,
        Java,
        Python,
        Ruby,
        Node,
        React,
        Angular,
        Vue,
        IOnlyDoHTMLAndCSS
    }
}
