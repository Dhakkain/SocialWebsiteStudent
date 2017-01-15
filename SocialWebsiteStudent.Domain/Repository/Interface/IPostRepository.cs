using System;
using System.Collections.Generic;
using System.Linq;
using SocialWebsiteStudent.Domain.Models;

namespace SocialWebsiteStudent.Domain.Repository.Interface
{
    public interface IPostRepository : IDisposable
    {
        List<Post> GetPosts();
        List<string> GetTag();

        void AddNewPost(Post post);
        void AddNewComment(Comment comment);
        void AddNewTag(Tag tag);
        void AddNewNotification(Notification notification);

        Post GetPostById(int id);
        ApplicationUser GetUser(string user);
        Tag GetSingleTag(string value);

        void SaveChanges();
    }
}