using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SocialWebsiteStudent.Domain.DatabaseContext;
using SocialWebsiteStudent.Domain.Models;
using SocialWebsiteStudent.Domain.Repository.Interface;

namespace SocialWebsiteStudent.Domain.Repository.Implementation
{
    public class AdminRepository : IAdminRepository
    {
        private readonly IApplicationDbContext _db;

        public AdminRepository(IApplicationDbContext db)
        {
            _db = db;
        }

        public Post GetPost(int id)
        {
            return _db.Posts.Find(id);
        }

        public Comment GetComment(int id)
        {
            return _db.Comments.Find(id);
        }

        public Notification GetNotification(int id)
        {
            return _db.Notifications.Find(id);
        }

        public void RemoveNotification( int id)
        {
           var deleteNotification=  from n in _db.Notifications where n.Post.ID == id select n;
            _db.Notifications.RemoveRange(deleteNotification);
        }

        public void RemovePost(Post post)
        {
            _db.Posts.Remove(post);
        }

        public void RemoveComment(Comment comment)
        {
            _db.Comments.Remove(comment);
        }

        public ApplicationUser BlockUser(string id)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>((DbContext) _db));

            ApplicationUser bannedUser;
            return  bannedUser = UserManager.FindById(id);
        }

        public void BlockUsername(string username)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>((DbContext)_db));
            var bannedUser = UserManager.FindByName(username);
            UserManager.AddToRole(bannedUser.Id, "UserBanned");
        }

        public async Task UnblockUser(string username)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>((DbContext) _db));

            var bannedUser = UserManager.FindByName(username);

            await UserManager.RemoveFromRolesAsync(bannedUser.Id, "UserBanned");
            await UserManager.UpdateAsync(bannedUser);
        }

        public void TakeAdmin(string username)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>((DbContext) _db));

            var adminUser = UserManager.FindByName(username);
            UserManager.AddToRole(adminUser.Id, "Admin");
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}