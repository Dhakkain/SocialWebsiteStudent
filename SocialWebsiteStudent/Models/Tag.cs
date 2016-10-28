using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialWebsiteStudent.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string TagName { get; set; }

        public virtual ICollection<TagPost> TagPost { get; set; }
    }

    public class TagPost
    {
        public int Id{ get; set; }
        public int PostId { get; set; }
        public int TagId { get; set; }

        public virtual Tag Tag { get; set; }
        public virtual Post Post { get; set; }
    }
}