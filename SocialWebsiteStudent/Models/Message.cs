using System;

namespace SocialWebsiteStudent.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string MessageTitle { get; set; }
        public string MessageContent { get; set; }
        public string ToUser { get; set; }
        public int ToUserId { get; set; }
        public int FromUserId { get; set; }
        public DateTime DateTimeOfMessage { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}