using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SocialWebsiteStudent.Models;

namespace SocialWebsiteStudent.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        //Everyone can view all post on wall
        [HttpGet]
        [AllowAnonymous]
        public ActionResult WallPost()
        {
            //Post orderby date of posting
            var postFromDatabase = _db.Posts.OrderByDescending(post => post.PostDateTime).ToList();

            return View(postFromDatabase);
        }

        //Only register user can post new topic
        [Authorize]
        public ActionResult PostingPost(string postContents)
        {
            //Get ID of user 
            var currentUserId = User.Identity.GetUserId();
            //Get object of Current login user
            var currentUser = _db.Users.FirstOrDefault(user => user.Id == currentUserId);

            //Create new object of Post - new Post
            var newPost = new Post
            {
                PostContent = postContents,
                PostDateTime = DateTime.Now,
                ApplicationUser = currentUser,
                Tags = new List<Tag>()
            };

            var regex = new Regex(@"#\w+");
            var matches = regex.Matches(postContents);

            var existTag = _db.Tags.Select(x => x.TagName);
            foreach (Match m in matches)
            {
                if (existTag.Contains(m.Value))
                {
                    var tagInPost = _db.Tags.Single(t => t.TagName == m.Value);
                    newPost.Tags.Add(tagInPost);
                }
                else
                {
                    var newTag = new Tag()
                    {
                        TagName = m.Value
                    };
                    _db.Tags.Add(newTag);
                    newPost.Tags.Add(newTag);
                    _db.Tags.Add(newTag);
                }
            }


            //Add new Post to database
            _db.Posts.Add(newPost);
            //Save changes in database 
            _db.SaveChanges();
            return RedirectToAction("WallPost");
        }

        //Only register user can post new comment
        //POST
        [Authorize]
        public ActionResult PostingComment(int id, string commentContents, string userName)
        {
            //Get ID of user 
            var currentUserId = User.Identity.GetUserId();
            //Get object of Current login user
            var currentUser = _db.Users.FirstOrDefault(user => user.Id == currentUserId);

            //Create new object of Post - new Post
            var newComment = new Comment
            {
                CommentContent = commentContents,
                CommentDateTime = DateTime.Now,
                ApplicationUser = currentUser,
                PostId = id,
            };

            //Add new Post to database
            _db.Comments.Add(newComment);
            //Save changes in database 
            _db.SaveChanges();

            var newCommentNotification = new Notification
            {
                NotificationTitle = "Skomentowany wpis!",
                NotificationContent = "Twój wpis skomentował użytkownik:" + User.Identity.Name,
                NotificationDateTime = DateTime.Now,
                Post = _db.Posts.FirstOrDefault(x => x.ID == id),
                ApplicationUser = _db.Users.FirstOrDefault(user => user.UserName == userName)
            };

            //Add new Notification to database
            _db.Notifications.Add(newCommentNotification);
            //Save changes in database 
            _db.SaveChanges();

            return RedirectToAction("WallPost");
        }

     
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

            return RedirectToAction("WallPost");
        }
    }
}