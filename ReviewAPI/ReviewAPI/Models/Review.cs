namespace ReviewAPI.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string ReviewTitle { get; set; } = string.Empty;
        public string ReviewContent { get; set; } = string.Empty ;
        public string Reported { get; set; } = string.Empty;
    }
}
