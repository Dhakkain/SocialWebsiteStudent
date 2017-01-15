using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using SocialWebsiteStudent.Domain.DatabaseContext;
using SocialWebsiteStudent.Domain.Models;
using SocialWebsiteStudent.Domain.Repository.Interface;
using SocialWebsiteStudent.Models;

namespace SocialWebsiteStudent.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostRepository _repo ;

        public PostController(IPostRepository repo)
        {
            _repo = repo;
        }

        //Everyone can view all post on wall
        [AllowAnonymous]
        public ActionResult WallPost()
        {
            //Post with comments orderby date of posting
            var postFromDatabase = _repo.GetPosts();

            // Return to main view wall with post nad comments
            return View(postFromDatabase);
        }

        //Only register user can post new topic
        [Authorize]
        public ActionResult PostingPost(string postContents)
        {
            // Empty postContetns
            if (postContents.IsNullOrWhiteSpace()) return RedirectToAction("WallPost");

            // Create new object of Post - new Post
            var newPost = new Post
            {
                PostContent = postContents,
                PostDateTime = DateTime.Now,
                ApplicationUser = _repo.GetUser(User.Identity.Name),
                Tags = new List<Tag>()
            };

            newPost.ApplicationUser.UserName = User.Identity.Name;

            // Regex- every word after "#"
            var regex = new Regex(@"#\w+");
            // Regex matches in postContents 
            var matches = regex.Matches(postContents);

            // Found every tag in database
            var existTag = _repo.GetTag();

            // Every match in postContents
            foreach (Match m in matches)
            {
                if (existTag.Contains(m.Value))
                {
                    var value = m.Value;
                    var tagInPost = _repo.GetSingleTag(value);
                    // Add tag to post 
                    newPost.Tags.Add(tagInPost);
                }
                else
                {
                    // Create new tag in database
                    var newTag = new Tag()
                    {
                        TagName = m.Value
                    };
                    _repo.AddNewTag(newTag);
                    // Add tag to post
                    newPost.Tags.Add(newTag);
                }
            }
            // Add new Post to database
            _repo.AddNewPost(newPost);
            // Save changes in database 
            try
            {
                _repo.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
            }

            // Return to wall with post 
            return RedirectToAction("WallPost");
        }

        //Only register user can post new comment
        [Authorize]
        public ActionResult PostingComment(int id, string commentContents, string userName)
        {
            if (commentContents.IsNullOrWhiteSpace()) return RedirectToAction("WallPost");

            //Create new object of Post - new Post
            var newComment = new Comment
            {
                CommentContent = commentContents,
                CommentDateTime = DateTime.Now,
                ApplicationUser = _repo.GetUser(User.Identity.Name),
                PostId = id,
            };

            //Add new Post to database
            _repo.AddNewComment(newComment);
            //Save changes in database 
            _repo.SaveChanges();

            var newCommentNotification = new Notification
            {
                NotificationTitle = "Skomentowany wpis!",
                NotificationContent = "Twój wpis skomentował użytkownik:" + User.Identity.Name,
                NotificationDateTime = DateTime.Now,
                Post = _repo.GetPostById(id),
                ApplicationUser = _repo.GetUser(userName)
            };

            //Add new Notification to database
            _repo.AddNewNotification(newCommentNotification);
            //Save changes in database 
            _repo.SaveChanges();

            return RedirectToAction("WallPost");
        }

     
    
    }
}