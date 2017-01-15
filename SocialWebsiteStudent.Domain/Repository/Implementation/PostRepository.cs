using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SocialWebsiteStudent.Domain.DatabaseContext;
using SocialWebsiteStudent.Domain.Models;
using SocialWebsiteStudent.Domain.Repository.Interface;

namespace SocialWebsiteStudent.Domain.Repository.Implementation
{
    public class PostRepository : IPostRepository
    {
        private readonly IApplicationDbContext _db;

        public PostRepository(IApplicationDbContext db)
        {
            _db = db;
        }

        public List<Post> GetPosts()
        {
            return _db.Posts.OrderByDescending(post => post.PostDateTime).ToList();
        }

        public void AddNewPost(Post post)
        {
            _db.Posts.Add(post);
        }

        public void AddNewNotification(Notification notification)
        {
            _db.Notifications.Add(notification);
        }

        public Post GetPostById(int id)
        {
            return _db.Posts.FirstOrDefault(x => x.ID == id);
        }

        public void AddNewTag(Tag tag)
        {
            _db.Tags.Add(tag);
        }

        public void AddNewComment(Comment comment)
        {
            _db.Comments.Add(comment);
        }

        public ApplicationUser GetUser(string user)
        {
            return _db.ApplicationUsers.Single(x => x.UserName == user);
        }

        public List<string> GetTag()
        {
           return _db.Tags.Select(x => x.TagName).ToList();
        }

        public Tag GetSingleTag(string value)
        {
            return _db.Tags.Single(t => t.TagName ==value);
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}