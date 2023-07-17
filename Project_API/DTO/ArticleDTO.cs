namespace Project_API.DTO
{
    public class ArticleDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? EditDate { get; set; } = DateTime.Now;
        public string? Summary { get; set; }
        public int UserId { get; set; }
    }
}
