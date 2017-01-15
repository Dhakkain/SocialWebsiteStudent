using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialWebsiteStudent.Domain.Models;

namespace SocialWebsiteStudent.Domain.Repository.Interface
{
    public interface IAdminRepository
    {
        Post GetPost(int id);
        Comment GetComment(int id);
        Notification GetNotification(int id);
        ApplicationUser BlockUser(string id);

        void RemoveNotification(int id);
        void RemovePost(Post post);
        void RemoveComment(Comment comment);
       
        void BlockUsername(string username);
        Task UnblockUser(string username);
        void TakeAdmin(string username);
        void SaveChanges();
    }
}
