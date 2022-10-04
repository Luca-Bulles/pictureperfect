namespace ContentAPI.Models
{
    public class Content
    {
        public int ContentId { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Cast { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;    
        public int Year { get; set; }
    }
}
