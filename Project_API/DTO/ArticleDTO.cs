namespace Project_API.DTO
{
    public class ArticleDTO
    {
        public int ArticleId { get; set; } 
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? EditDate { get; set; } = DateTime.Now;
        public int? View { get; set; }
        public string? Summary { get; set; }
        public int UserId { get; set; }
        public List<CategoryDTO> Categories { get; set; }
    }
}
