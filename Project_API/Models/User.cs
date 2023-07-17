using System;
using System.Collections.Generic;

namespace Project_API.Models
{
    public partial class User
    {
        public User()
        {
            Articles = new HashSet<Article>();
        }

        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string? Description { get; set; }
        public string? Img { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
