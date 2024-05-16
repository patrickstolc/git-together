namespace DevRanker.Model
{
    public class RankProfile
    {

        private double _rank;
        public double Rank
        {
            get { return _rank; } set
            {
                _rank = Math.Min(Math.Max(value, 0), 10);
            }
        }
        public Profile Profile {get; set;}
    }
}
