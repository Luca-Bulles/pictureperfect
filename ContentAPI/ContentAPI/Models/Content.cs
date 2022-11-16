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

        public Content(int contentId, string category, string name, string subject, string description, string cast, string duration, int year)
        {
            ContentId = contentId;
            Category = category;
            Name = name;
            Subject = subject;
            Description = description;
            Cast = cast;
            Duration = duration;
            Year = year;
        }
    }
}
