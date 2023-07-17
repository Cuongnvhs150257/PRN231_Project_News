using System;
using System.Collections.Generic;

namespace Project_API.Models
{
    public partial class Category
    {
        public Category()
        {
            Articles = new HashSet<Article>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;

        public virtual ICollection<Article> Articles { get; set; }
    }
}
