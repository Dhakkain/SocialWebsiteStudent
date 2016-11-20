using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using SocialWebsiteStudent.Models;

namespace SocialWebsiteStudent.Controllers
{
    public class MessageController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        [Authorize]
        [HttpGet]
        public ActionResult Inbox()
        {
            //Select all conversation for User who is log in
            var inboxMessage = (from message in _db.Messages
                where message.ToUserName == User.Identity.Name || message.FromUserName == User.Identity.Name
                orderby message.DateTimeOfMessage descending
                select message);

            return View(inboxMessage.ToList());
        }

        [Authorize]
        [HttpPost]
        public ActionResult ShowMessage(string toUser, string messageContent)
        {
            //Create new object of Message 
            var newMessage = new Message
            {
                MessageContent = messageContent,
                DateTimeOfMessage = DateTime.Now,
                FromUserName = User.Identity.Name,
                ToUserName = toUser
            };

            //Add new Message to database
            _db.Messages.Add(newMessage);
            //Save changes in database 
            _db.SaveChanges();


            var newMessageNotification = new Notification
            {
                NotificationTitle = "Nowa wiadomość!",
                NotificationContent = "Nowa wiadomość od: " + User.Identity.Name,
                NotificationDateTime = DateTime.Now,
                Message = _db.Messages.FirstOrDefault(x => x.Id == newMessage.Id),
                ApplicationUser = _db.Users.FirstOrDefault(user => user.UserName == toUser)
            };

            _db.Notifications.Add(newMessageNotification);
            //Save changes in database 
            _db.SaveChanges();

            return RedirectToAction("ShowMessage", "Message", new {username = toUser});
        }

        [Authorize]
        [HttpGet]
        public ActionResult ShowMessage(string username)
        {
            //Get ID of user 
            var currentUserId = User.Identity.GetUserId();
            //Get object of Current login user
            var currentUser = _db.Users.FirstOrDefault(user => user.Id == currentUserId);

            //Select all message from conversation by two user
            var selectMessage = (from message in _db.Messages
                where (message.FromUserName == username && message.ToUserName == currentUser.UserName)
                      || (message.FromUserName == currentUser.UserName && message.ToUserName == username)
                orderby message.DateTimeOfMessage descending
                select message).ToList();

            return View(selectMessage);
        }


        [Authorize]
        public ActionResult CreateNewMessage()
        {
            return View();
        }


        [Authorize]
        [HttpPost]
        public ActionResult CreateNewMessage(string toUser, string messageContent)
        {
            // User can't write a message to yourself
            if (toUser == User.Identity.Name)
            {
                return RedirectToAction("CreateNewMessage", "Message");
            }

            //Create new object of Message 
            var newMessage = new Message
            {
                MessageContent = messageContent,
                DateTimeOfMessage = DateTime.Now,
                FromUserName = User.Identity.Name,
                ToUserName = toUser
            };

            //Add new Message to database
            _db.Messages.Add(newMessage);
            //Save changes in database 
            _db.SaveChanges();

            var newMessageNotification = new Notification
            {
                NotificationTitle = "Nowa wiadomość!",
                NotificationContent = "Nowa wiadomość od: " + User.Identity.Name,
                NotificationDateTime = DateTime.Now,
                Message = _db.Messages.FirstOrDefault(x => x.Id == newMessage.Id),
                ApplicationUser = _db.Users.FirstOrDefault(user => user.UserName == toUser)
            };

            _db.Notifications.Add(newMessageNotification);

            //Save changes in database 
            _db.SaveChanges();

            return RedirectToAction("ShowMessage", new {username = toUser});
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}