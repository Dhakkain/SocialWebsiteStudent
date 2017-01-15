using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SocialWebsiteStudent.Domain.DatabaseContext;
using SocialWebsiteStudent.Domain.Models;
using SocialWebsiteStudent.Domain.Repository.Interface;

namespace SocialWebsiteStudent.Domain.Repository.Implementation
{
    public class SearchRepository : ISearchRepository
    {

        private readonly IApplicationDbContext _db;

        public SearchRepository(IApplicationDbContext db)
        {
            _db = db;
        }

        public List<Post> GetFoundContent(string foundContent)
        {
           return (from f in _db.Posts
             where
             f.PostContent.Contains(foundContent) || f.Comment.Any(x => x.CommentContent.Contains(foundContent))
             orderby f.PostDateTime
             select f).ToList();

        }
    }
}