using System;
using System.Data;
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
            var inboxMessage = (from m in _db.Messages
                                where m.ToUserName == User.Identity.Name
                                orderby m.DateTimeOfMessage descending
                                select m);

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

            return RedirectToAction("ShowMessage","Message", new {username = toUser});
        }

        [Authorize]
        [HttpGet]
        public ActionResult ShowMessage(string username)
        {
            //Get ID of user 
            var currentUserId = User.Identity.GetUserId();
            //Get object of Current login user
            var currentUser = _db.Users.FirstOrDefault(x => x.Id == currentUserId);



            var selectMessage = (from m in _db.Messages
                                 where (m.FromUserName == username && m.ToUserName == currentUser.UserName)
                                 ||(m.FromUserName == currentUser.UserName && m.ToUserName == username) 
                                 orderby m.DateTimeOfMessage descending 
                                 select m).ToList();


            return View(selectMessage);
        }

        [Authorize]
        [HttpGet]
        public ActionResult CreateNewMessage()
        {

            return View("CreateMessage");
        }


        [Authorize]
        [HttpPost]
        public ActionResult CreateNewMessage(string toUser, string messageContent)
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

            return View("CreateMessage");
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