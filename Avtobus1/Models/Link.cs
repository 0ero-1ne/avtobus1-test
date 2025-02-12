namespace Avtobus1.Models
{
    public class Link
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? ShortName { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Redirects { get; set; }
    }
}
