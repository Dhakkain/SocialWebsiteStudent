using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SocialWebsiteStudent.Domain.DatabaseContext;
using SocialWebsiteStudent.Domain.Models;
using SocialWebsiteStudent.Domain.Repository.Interface;

namespace SocialWebsiteStudent.Domain.Repository.Implementation
{
    public class TagRepository : ITagRepository
    {
        private readonly IApplicationDbContext _db;
        public TagRepository(IApplicationDbContext db)
        {
            _db = db;
        }

        public List<Post> GetPostsFromTags(string tagName)
        {
            return (from post in _db.Posts
                where
                post.Tags.Any(tag => tag.TagName == tagName)
                orderby post.PostDateTime
                select post).ToList();
        }
    }
}