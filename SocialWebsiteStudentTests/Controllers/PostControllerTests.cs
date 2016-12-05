using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialWebsiteStudent.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Moq;
using SocialWebsiteStudent.Models;

namespace SocialWebsiteStudent.Controllers.Tests
{
    [TestClass()]
    public class PostControllerTests
    {
        [TestMethod()]
        public void PostingCommentTest()
        {
           
        }

        [TestMethod()]
        public void WallPostTest()
        {
            var mockset = new Mock<DbSet<Post>>();
            var mockContext = new Mock<ApplicationDbContext>();

            mockContext.Setup(m => m.Posts).Returns(mockset.Object);

        }

        [TestMethod()]
        public void PostingPostTest()
        {
            var mockset = new Mock<DbSet<Post>>();
            var mockContext = new Mock<ApplicationDbContext>();

            mockContext.Setup(m => m.Posts).Returns(mockset.Object);

        }

   

        [TestMethod()]
        public void DeletePostTest()
        {
            var mockset = new Mock<DbSet<Post>>();
            var mockContext = new Mock<ApplicationDbContext>();

            mockContext.Setup(m => m.Posts).Returns(mockset.Object);

        }
    }
}