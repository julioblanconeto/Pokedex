namespace Pokedex.Model
{
    public class Result
    {
        public int Count { get; set; }
        public string? Next { get; set; }
        public string? Previous { get; set; }
        public List<Results> Results { get; set; }
    }

    public class Results
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}


