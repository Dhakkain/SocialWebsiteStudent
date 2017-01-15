using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialWebsiteStudent.Domain.Models;

namespace SocialWebsiteStudent.Domain.DatabaseContext
{
    public interface IApplicationDbContext
    {
        DbSet<ApplicationUser> ApplicationUsers { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<Message> Messages { get; set; }
        DbSet<Notification> Notifications { get; set; }
        DbSet<Tag> Tags { get; set; }
        Database Databases { get; }
        int SaveChanges();
        void Dispose();
    }
}
