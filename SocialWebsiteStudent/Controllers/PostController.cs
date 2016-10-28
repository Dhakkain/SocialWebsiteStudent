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
        //GET 
        [HttpGet]
        [AllowAnonymous]
        public ActionResult WallPost()
        {
            //Post orderby date of posting
            var postFromDatabase = _db.Posts.OrderByDescending(x=> x.PostDateTime).ToList();

            return View(postFromDatabase);
        }

        //Only register user can post new comment
        //POST
        [Authorize]
        [HttpPost]
        public ActionResult PostingComment(string commentContents, int id)
        {
            //Get ID of user 
            var currentUserId = User.Identity.GetUserId();
            //Get object of Current login user
            var currentUser = _db.Users.FirstOrDefault(x => x.Id == currentUserId);

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
            var currentUser = _db.Users.FirstOrDefault(x => x.Id == currentUserId);

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
    }
}