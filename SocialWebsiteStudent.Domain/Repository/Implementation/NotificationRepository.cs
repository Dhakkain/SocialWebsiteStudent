using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SocialWebsiteStudent.Domain.DatabaseContext;
using SocialWebsiteStudent.Domain.Models;
using SocialWebsiteStudent.Domain.Repository.Interface;

namespace SocialWebsiteStudent.Domain.Repository.Implementation
{
    public class NotificationRepository : INotificationRepository
    {
         private readonly IApplicationDbContext _db;

        public NotificationRepository(IApplicationDbContext db)
        {
            _db = db;
        }


        public List<Notification> GetNotifications(ApplicationUser applicationUser)
        {
            return (from notification in _db.Notifications
                where notification.ApplicationUser.Id == applicationUser.Id && notification.Open == false
                select notification).ToList();
        }

        public List<Post> GetPostById(int id)
        {
            return (from postin in _db.Posts
             where postin.ID == id
             select postin).ToList();
        }

        public Notification SetOpenedMessage(int id)
        {
            return _db.Notifications.FirstOrDefault(x => x.Message.Id == id && x.Open == false);

        }

        public Notification SetOpenedPost(int id)
        {
            return _db.Notifications.FirstOrDefault(x => x.Post.ID == id && x.Open == false);



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