using Suggestion.Core.Entities;

namespace Suggestion.Core.Entiies
{
    public class Suggestion
    {
        public int Id { get; set; }
        public List<RankProfile> profileRankings { get; set; }
        public Profile profile { get; set; }
    }
}
