using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialWebsiteStudent.Domain.Models;

namespace SocialWebsiteStudent.Domain.Repository.Interface
{
    public interface IUserRepository
    {
        List<Post> GetPosts(string username);
        List<ApplicationUser> GetUser(string username);
        ApplicationUser GetUserByName(string name);


        void SaveChanges();
        void AddOrUpdate(ApplicationUser applicationUser);
    }
}