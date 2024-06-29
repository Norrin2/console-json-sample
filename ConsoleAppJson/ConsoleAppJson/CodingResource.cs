namespace ConsoleAppJson
{
    public class CodingResource
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public IEnumerable<string> Types { get; set; }
        public IEnumerable<string> Topics { get; set; }
        public IEnumerable<string> Levels { get; set; }
    }
}
