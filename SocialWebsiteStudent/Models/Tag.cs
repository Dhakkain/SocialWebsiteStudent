using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialWebsiteStudent.Models
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