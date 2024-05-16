using Suggestion.Core.Entities;

namespace Suggestion.Core.Entiies
{
    public class Suggestion
    {
        public int Id { get; set; }
        public List<RankProfile> ProfileRankings { get; set; }

        public int userID { get; set; }
    }
}
