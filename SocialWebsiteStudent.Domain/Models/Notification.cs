using System;
using Microsoft.AspNet.Identity.EntityFramework;
using SocialWebsiteStudent.Domain.DatabaseContext;

namespace SocialWebsiteStudent.Domain.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string NotificationTitle { get; set; }
        public string NotificationContent { get; set; }
        public DateTime NotificationDateTime { get; set; }
        public bool Open { get; set; }

        public virtual IdentityUser ApplicationUser { get; set; }
        public virtual Post Post { get; set; }
        public virtual Message Message { get; set; }
    }
}