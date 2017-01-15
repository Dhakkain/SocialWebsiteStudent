using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialWebsiteStudent.Domain.Models;

namespace SocialWebsiteStudentTests.Helpers
{
    class DataGenerator
    {
        public List<Post> Posts { get; private set; }

        public List<Tag> Tags { get; private set; }

        public List<ApplicationUser> Users { get; private set; }

        public List<Comment> Comments { get; set; }

        public List<Message> Messages { get; set; }

        public DataGenerator()
        {
            GenerateUsers();
            GenarateTags();
            GeneratePost();
            GenerateComments();
            Tags.ForEach(x => x.Posts = Posts);
        }

        private void GeneratePost()
        {
            Posts = new List<Post>()
            {
                new Post(){ID = 1,PostDateTime = DateTime.Now,PostContent= "a",ApplicationUser = Users[0]},
                new Post(){ID = 2,PostDateTime = DateTime.Now,PostContent= "b",ApplicationUser = Users[0]},
                new Post(){ID = 3,PostDateTime = DateTime.Now,PostContent= "c",ApplicationUser = Users[1]},
                new Post(){ID = 4,PostDateTime = DateTime.Now,PostContent= "d",ApplicationUser = Users[1]},
                new Post(){ID = 5,PostDateTime = DateTime.Now,PostContent= "e",ApplicationUser = Users[1]},
                new Post(){ID = 6,PostDateTime = DateTime.Now,PostContent= "f",ApplicationUser = Users[0]},
            };
        }

        private void GenerateComments()
        {
            Comments = new List<Comment>()
            {
                new Comment(){ApplicationUser= Users[0],ID = 1, CommentContent = "Test",PostId = 1},
                new Comment(){ApplicationUser= Users[0],ID = 1, CommentContent = "Test",PostId = 2},
                new Comment(){ApplicationUser= Users[1],ID = 1, CommentContent = "Test",PostId = 3},
                new Comment(){ApplicationUser= Users[1],ID = 1, CommentContent = "Test",PostId = 2},
                new Comment(){ApplicationUser= Users[0],ID = 1, CommentContent = "saddasd",PostId = 5},
            };
        }

        private void GenarateTags()
        {
            Tags = new List<Tag>()
             {
                 new Tag()
                 {
                     Id = 1,
                     TagName = "java",
                 },
                 new Tag()
                 {
                     Id = 2,
                     TagName = "csharp",
                 },
                 new Tag()
                 {
                     Id = 3,
                     TagName = "programowanie",
                 },
                 new Tag()
                 {
                     Id = 4,
                     TagName = "heheszki",
                 }
             };
        }

        private void GenerateUsers()
        {
            Users = new List<ApplicationUser>()
            {
                new ApplicationUser()
                {
                    Id = "pierwszyuzytkownik123",
                    UserName = "Pierwszy"
                },
                new ApplicationUser()
                {
                    Id = "Drugiuzytkownika213123",
                    UserName = "Drugi"
                },
            };
        }

     
        public static DataGenerator Get() => new DataGenerator();
    }
}
