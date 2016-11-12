using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Services;
using System.Web.Services;
using Microsoft.AspNet.Identity;
using SocialWebsiteStudent.Models;
using Microsoft.AspNet.Identity.Owin;

namespace SocialWebsiteStudent.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        [HttpGet]
        public ActionResult ProfileSite(string name)
        {
            var profileView = (from post in _db.Posts
                               where post.ApplicationUser.UserName == name
                               select post);

            return View(profileView.ToList());
        }

        [HttpGet]
        public ActionResult ProfileOptions()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProfileAvatar(HttpPostedFileBase UserPhoto)
        {
            byte[] imageData = null;

            if (Request.Files.Count > 0)
            {
                var poImgFile = Request.Files["UserPhoto"];
                if (poImgFile != null)
                    using (var binary = new BinaryReader(poImgFile.InputStream))
                    {
                        imageData = binary.ReadBytes(poImgFile.ContentLength);
                    }
            }

            var user = _db.Users.First(x => x.UserName == User.Identity.Name);
            user.UserPhoto = imageData;
            _db.Users.AddOrUpdate(user);
            _db.SaveChanges();

            return RedirectToAction("ProfileOptions");
        }


        [HttpPost]
        public JsonResult GetUser(string term)
        {
            var result = (from user in _db.Users
                where user.UserName.StartsWith(term)
                select new
                {
                    startfrom = user.UserName
                }).Distinct();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public FileContentResult UserPhotos(string id)
        {

            if (id == null)
            {
                string fileName = HttpContext.Server.MapPath(@"~/Content/Image/noImage.png");

                byte[] imageData = null;
                FileInfo fileInfo = new FileInfo(fileName);
                long imageFileLength = fileInfo.Length;
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                imageData = br.ReadBytes((int)imageFileLength);

                return File(imageData, "image/png");

            }

            // to get the user details to load user Image 
            var bdUsers = HttpContext.GetOwinContext().Get<ApplicationDbContext>();
            var userImage = bdUsers.Users.FirstOrDefault(x => x.Id == id);

            return new FileContentResult(userImage.UserPhoto, "image/jpeg");
        }
    }
}