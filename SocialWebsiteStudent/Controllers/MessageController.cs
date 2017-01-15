using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using SocialWebsiteStudent.Domain.DatabaseContext;
using SocialWebsiteStudent.Domain.Models;
using SocialWebsiteStudent.Domain.Repository.Interface;
using SocialWebsiteStudent.Models;

namespace SocialWebsiteStudent.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessageRepository _repo;

        public MessageController(IMessageRepository repo)
        {
            _repo = repo;
        }

        [Authorize]
        [HttpGet]
        public ActionResult Inbox()
        {
            var currentUser = _repo.GetUser(User.Identity.Name);
            //Select all conversation for User who is log in
            var inboxMessage = _repo.GetMessages(currentUser);

            return View(inboxMessage);
        }

        [Authorize]
        [HttpPost]
        public ActionResult ShowMessage(string toUser, string messageContent)
        {
            if (messageContent.IsNullOrWhiteSpace())
            {
                return RedirectToAction("ShowMessage");
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
            _repo.AddNewMessage(newMessage);
            //Save changes in database 
            _repo.SaveChanges();


            var newMessageNotification = new Notification
            {
                NotificationTitle = "Nowa wiadomość!",
                NotificationContent = "Nowa wiadomość od: " + User.Identity.Name,
                NotificationDateTime = DateTime.Now,
                Message = _repo.GetMessageById(newMessage.Id),
                ApplicationUser = _repo.GetUser(toUser)
            };

            _repo.AddNewNotification(newMessageNotification);
            //Save changes in database 
            _repo.SaveChanges();

            return RedirectToAction("ShowMessage", "Message", new {username = toUser});
        }

        [Authorize]
        [HttpGet]
        public ActionResult ShowMessage(string username)
        {
            //Get object of Current login user
            var currentUser = _repo.GetUser(User.Identity.Name);
            //Select all message from conversation by two user
            var selectMessage = _repo.GetMessagesForUser(username, currentUser);

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
            if (messageContent.IsNullOrWhiteSpace())
            {
                return RedirectToAction("CreateNewMessage");
            }
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
            _repo.AddNewMessage(newMessage);
            //Save changes in database 
            _repo.SaveChanges();

            var newMessageNotification = new Notification
            {
                NotificationTitle = "Nowa wiadomość!",
                NotificationContent = "Nowa wiadomość od: " + User.Identity.Name,
                NotificationDateTime = DateTime.Now,
                Message = _repo.GetMessageById(newMessage.Id),
                ApplicationUser = _repo.GetUser(toUser)
            };


            _repo.AddNewNotification(newMessageNotification);
            //Save changes in database 
            _repo.SaveChanges();
            return RedirectToAction("ShowMessage", new {username = toUser});
        }
    }
}