using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SocialWebsiteStudent.Models;

namespace SocialWebsiteStudent.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();


        [Authorize]
        public ActionResult DeletePost(int id)
        {
            //Find post in database
            var deletePost = _db.Posts.Find(id);

            var deleteNotification = from n in _db.Notifications where n.Post.ID == id select n;
            //Remove notifications from db
            _db.Notifications.RemoveRange(deleteNotification);

            //Remove post and his comments from db
            _db.Posts.Remove(deletePost);
            //Save
            _db.SaveChanges();

            return RedirectToAction("WallPost", "Post");
        }

        [Authorize]
        public ActionResult DeleteComment(int id)
        {
            //Find post in database
            var deleteComment = _db.Comments.Find(id);

            //Remove post and his comments from db
            _db.Comments.Remove(deleteComment);
            //Save
            _db.SaveChanges();

            return RedirectToAction("WallPost", "Post");
        }

        [Authorize]
        public ActionResult BlockUser(string id)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_db));

            var bannedUser = UserManager.FindById(id);
            
            return RedirectToAction("BlockUserName", "Admin", new {username = bannedUser});
        }
        [Authorize]
        public ActionResult BlockUserName(string username)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_db));

            var bannedUser = UserManager.FindByName(username);
            UserManager.AddToRole(bannedUser.Id, "UserBanned");

            return RedirectToAction("ProfileSite", "User", new { name = username });
        }
        [Authorize]
        public async Task<ActionResult> UnblockUser(string username)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_db));

            var bannedUser = UserManager.FindByName(username);

            await UserManager.RemoveFromRolesAsync(bannedUser.Id, "UserBanned");
            await UserManager.UpdateAsync(bannedUser);

            return RedirectToAction("ProfileSite", "User", new { name = username });
        }

        [Authorize]
        public ActionResult TakeAdminClaim(string username)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_db));

            var adminUser = UserManager.FindByName(username);
            UserManager.AddToRole(adminUser.Id, "Admin");
            return RedirectToAction("ProfileSite","User", new { name = username});
        }

    }
}