using System.Collections.Generic;

namespace SocialWebsiteStudent.Domain.Models
{
    public class Tag
    {
        public Tag()
        {
            this.Posts = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string TagName { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}