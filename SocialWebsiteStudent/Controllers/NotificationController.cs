using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SocialWebsiteStudent.Domain.DatabaseContext;
using SocialWebsiteStudent.Domain.Repository.Interface;
using SocialWebsiteStudent.Models;

namespace SocialWebsiteStudent.Controllers
{
    public class NotificationController : Controller
    {
        private readonly INotificationRepository _repo;

        public NotificationController(INotificationRepository repo)
        {
            _repo = repo;
        }

        [Authorize]
        public ActionResult Notification()
        {
            var currentUser = _repo.GetUser(User.Identity.Name);

            var notificationForUser = _repo.GetNotifications(currentUser);

            return View(notificationForUser);
        }

        [Authorize]
        public ActionResult ShowPost(int id)
        {
            var modify = _repo.SetOpenedMessage(id);
            if (modify != null)
            {
                modify.Open = true;
                _repo.SaveChanges();
            }


            var showPost = _repo.GetPostById(id);

            return View(showPost);
        }

        [Authorize]
        public ActionResult ShowNotificationMessage(int id)
        {
            var modify = _repo.SetOpenedMessage(id);
            if (modify != null)
            {
                modify.Open = true;   
                _repo.SaveChanges();
            }


            return RedirectToAction("Inbox", "Message");
        }
    }
}