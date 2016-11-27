using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialWebsiteStudent.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SocialWebsiteStudent.Controllers.Tests
{
    [TestClass()]
    public class PostControllerTests
    {
        [TestMethod()]
        public void PostingCommentTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void WallPostTest()
        {

            PostController controller = new PostController();
            ViewResult result = controller.WallPost() as ViewResult;
            Assert.Equals("WallPost", result.ViewName);
        }

        [TestMethod()]
        public void PostingPostTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PostingCommentTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeletePostTest()
        {
            Assert.Fail();
        }
    }
}