using System.Data.Entity;
using System.Runtime.Remoting.Contexts;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SocialWebsiteStudent.Domain.Models;

namespace SocialWebsiteStudent.Domain.DatabaseContext
{
    public class ApplicationDbContext : IdentityDbContext, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public Database Databases { get; }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

       
    }
}