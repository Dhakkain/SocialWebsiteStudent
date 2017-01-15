using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Microsoft.VisualBasic.ApplicationServices;
using SocialWebsiteStudent.Domain.DatabaseContext;
using SocialWebsiteStudent.Domain.Models;
using SocialWebsiteStudent.Domain.Repository.Interface;

namespace SocialWebsiteStudent.Domain.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly IApplicationDbContext _db;

        public UserRepository(IApplicationDbContext db)
        {
            _db = db;
        }

        public List<Post> GetPosts(string username)
        {
            return (from post in _db.Posts
                where post.ApplicationUser.UserName == username
                orderby post.PostDateTime
                select post).ToList();
        }

        public List<ApplicationUser> GetUser(string username)
        {
            return (from p in _db.ApplicationUsers where p.UserName == username select p).ToList();
        }

        public ApplicationUser GetUserByName(string name)
        {
            return _db.ApplicationUsers.First(x => x.UserName == name);
        }

      
        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public void AddOrUpdate(ApplicationUser applicationUser)
        {
            _db.ApplicationUsers.AddOrUpdate(applicationUser);
        }
    }
}