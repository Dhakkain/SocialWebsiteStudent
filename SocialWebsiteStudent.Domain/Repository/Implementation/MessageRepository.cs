using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using Microsoft.VisualBasic.ApplicationServices;
using SocialWebsiteStudent.Domain.DatabaseContext;
using SocialWebsiteStudent.Domain.Models;
using SocialWebsiteStudent.Domain.Repository.Interface;

namespace SocialWebsiteStudent.Domain.Repository.Implementation
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IApplicationDbContext _db;

        public MessageRepository(IApplicationDbContext db)
        {
            _db = db;
        }

        public List<Message> GetMessages(ApplicationUser applicationUser)
        {
            return (from msg in _db.Messages
                where msg.ToUserName == applicationUser.UserName
                orderby msg.DateTimeOfMessage descending
                select msg).ToList();
        }
      
       
        public Message GetMessageById(int id)
        {
            return _db.Messages.FirstOrDefault(x => x.Id == id);
        }

        public void AddNewMessage(Message message)
        {
            _db.Messages.Add(message);
        }

        public void AddNewNotification(Notification notification)
        {
            _db.Notifications.Add(notification);
        }

        public List<Message> GetMessagesForUser(string username, ApplicationUser applicationUser)
        {
            return (from message in _db.Messages
                where (message.FromUserName == username && message.ToUserName == applicationUser.UserName)
                      || (message.FromUserName == applicationUser.UserName && message.ToUserName == username)
                orderby message.DateTimeOfMessage descending
                select message).ToList();
        }

        public ApplicationUser GetUser(string user)
        {
            return _db.ApplicationUsers.Single(x => x.UserName == user);
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}