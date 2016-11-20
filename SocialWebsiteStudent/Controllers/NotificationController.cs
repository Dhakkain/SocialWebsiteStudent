using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SocialWebsiteStudent.Models;

namespace SocialWebsiteStudent.Controllers
{
    public class NotificationController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        [Authorize]
        public ActionResult Notification()
        {
            var currentUserId = User.Identity.GetUserId();

            var notificationForUser = (from notification in _db.Notifications
                where notification.ApplicationUser.Id == currentUserId && notification.Open == false
                select notification).ToList();


            return View(notificationForUser);
        }

        [Authorize]
        public ActionResult ShowPost(int id)
        {
            var modify = _db.Notifications.FirstOrDefault(x => x.Post.ID == id && x.Open == false);

            modify.Open = true;
            _db.SaveChanges();

            var showPost = (from postin in _db.Posts
                where postin.ID == id
                select postin);

            return View(showPost.ToList());
        }

        [Authorize]
        public ActionResult ShowNotificationMessage(int id)
        {
            var modify = _db.Notifications.FirstOrDefault(x => x.Message.Id == id && x.Open == false);

            modify.Open = true;
            _db.SaveChanges();
            return RedirectToAction("Inbox", "Message");
        }
    }
}