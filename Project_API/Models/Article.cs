using System;
using System.Collections.Generic;

namespace Project_API.Models
{
    public partial class Article
    {
        public Article()
        {
            Categories = new HashSet<Category>();
        }

        public int ArticleId { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public DateTime? EditDate { get; set; }
        public int? View { get; set; }
        public string? Summary { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;

        public virtual ICollection<Category> Categories { get; set; }
    }
}
