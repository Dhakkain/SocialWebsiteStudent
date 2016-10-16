using System;

namespace SocialWebsiteStudent.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public string CommentContent { get; set; }
        public DateTime CommentDateTime { get; set; }
        public int PostId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Post Post { get; set; }
    }
}