namespace CodeVerifier.Models
{
    public class Problem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Task { get; set; }
        public string InputExample { get; set; }
        public string OutputExample { get; set; }
    }
}