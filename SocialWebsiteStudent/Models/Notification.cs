using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialWebsiteStudent.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string NotificationTitle{ get; set; }
        public string NotificationContent { get; set; }
        public int PostId { get; set; }
        public int CommentId { get; set; }
        public int MessageId { get; set; }
        public DateTime NotificationDateTime { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Post Post { get; set; }
        public virtual Message Message { get; set; }

    }
}