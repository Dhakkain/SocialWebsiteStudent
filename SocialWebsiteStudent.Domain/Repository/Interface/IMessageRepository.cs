using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialWebsiteStudent.Domain.Models;

namespace SocialWebsiteStudent.Domain.Repository.Interface
{
    public interface IMessageRepository
    {
        List<Message> GetMessages(ApplicationUser applicationUser);
        List<Message> GetMessagesForUser(string username, ApplicationUser applicationUser);
       

        void AddNewMessage(Message message);
        void AddNewNotification(Notification notification);

        Message GetMessageById(int id);
        ApplicationUser GetUser(string user);

        void SaveChanges();

    }
}
