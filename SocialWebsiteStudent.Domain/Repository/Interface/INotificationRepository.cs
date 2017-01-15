using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialWebsiteStudent.Domain.Models;

namespace SocialWebsiteStudent.Domain.Repository.Interface
{
    public interface INotificationRepository
    {
        List<Notification> GetNotifications(ApplicationUser applicationUser);
        List<Post> GetPostById(int id);

        Notification SetOpenedMessage(int id);
        Notification SetOpenedPost(int id);

        ApplicationUser GetUser(string user);

        void SaveChanges();
    }
}