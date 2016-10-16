using System;
using System.Collections.Generic;

namespace SocialWebsiteStudent.Models
{

    public class Post
    {
        public int ID { get; set; }
        public string PostContent { get; set; }
        public DateTime PostDateTime { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
    }
}