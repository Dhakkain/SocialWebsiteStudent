using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialWebsiteStudent.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string MessageContent { get; set; }
        public string ToUserName { get; set; }
        public string FromUserName { get; set; }

        public DateTime DateTimeOfMessage { get; set; }

    }
}