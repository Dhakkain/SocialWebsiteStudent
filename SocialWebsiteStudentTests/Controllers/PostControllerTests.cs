using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialWebsiteStudentTests.Helpers;
using NUnit.Framework;
using SocialWebsiteStudent.Domain.DatabaseContext;
using SocialWebsiteStudent.Domain.Models;
using SocialWebsiteStudent.Domain.Repository.Interface;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace SocialWebsiteStudent.Controllers.Tests
{
    [TestClass()]
    public class PostControllerTests
    {

        private DataGenerator _data;
        private PostController _controller;

       

        [TestMethod()]
        public void PostingCommentTest()
        {
           
        }

        [TestMethod]
        public void WallPostTest()
        {
            _data = new DataGenerator();
            Mock<IPostRepository> mockPost = new Mock<IPostRepository>();

            // Return all the products
            mockPost.Setup(mr => mr.GetPosts()).Returns(_data.Posts);

            Assert.IsNotNull(mockPost);
            Assert.AreEqual(6, _data.Posts.Count);
        }


        [TestMethod()]
        public void PostingPostTest()
        {
            _data = new DataGenerator();

            Post newPost = new Post()
            {
                ID = 8,
                PostDateTime = DateTime.Now,
                PostContent = "b",
                ApplicationUser = _data.Users[0]
            };
            Mock<IPostRepository> mockPost = new Mock<IPostRepository>();

            // Return all the products
            mockPost.Setup(m => m.AddNewPost(newPost));

        //    mockPost.Verify(x=>x.AddNewPost(It.IsAny<>), Times.Once);
            Mock<IPostRepository> mockPost1 = new Mock<IPostRepository>();

            // Return all the products
            mockPost1.Setup(mr => mr.GetPosts()).Returns(_data.Posts);

            Assert.IsNotNull(mockPost);
            Assert.AreEqual(7, _data.Posts.Count());

        }



        [TestMethod()]
        public void DeletePostTest()
        {
            //var mockset = new Mock<DbSet<Post>>();
            //var mockContext = new Mock<ApplicationDbContext>();

            //mockContext.Setup(m => m.Posts).Returns(mockset.Object);

        }
    }
}