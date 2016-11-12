using System;
using System.Linq;
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

        //Only register user can post new comment
        //POST
        [Authorize]
        [HttpPost]
        public ActionResult PostingComment(int id, string commentContents)
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
                PostId = id
            };

            //Add new Post to database
            _db.Comments.Add(newComment);
            //Save changes in database 
            _db.SaveChanges();
            return RedirectToAction("WallPost");
        }

        //Only register user can post new topic
        //POST
        [Authorize]
        [HttpPost]
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
                ApplicationUser = currentUser
            };

            //Add new Post to database
            _db.Posts.Add(newPost);
            //Save changes in database 
            _db.SaveChanges();
            return RedirectToAction("WallPost");
        }

        public ActionResult DeletePost(int id)
        {
            //Find post in database
            var deletePost = _db.Posts.Find(id);
            //Remove post and his comments from db
            _db.Posts.Remove(deletePost);
            //Save
            _db.SaveChanges();

            return RedirectToAction("WallPost");
        }
    }
}