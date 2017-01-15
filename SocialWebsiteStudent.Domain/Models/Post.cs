using System;
using System.Collections.Generic;
using SocialWebsiteStudent.Domain.DatabaseContext;

namespace SocialWebsiteStudent.Domain.Models
{
    public class Post
    {
        public Post()
        {
            this.Tags = new HashSet<Tag>();
        }

        public int ID { get; set; }
        public string PostContent { get; set; }
        public DateTime PostDateTime { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}