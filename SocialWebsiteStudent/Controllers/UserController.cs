using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Microsoft.Ajax.Utilities;
using SocialWebsiteStudent.Models;
using Microsoft.AspNet.Identity.Owin;

namespace SocialWebsiteStudent.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        public ActionResult ProfileSite(string name)
        {
            var profileView = (from post in _db.Posts
                where post.ApplicationUser.UserName == name
                orderby post.PostDateTime
                select post);
            if (!profileView.Any())
            {
                return RedirectToAction("ProfileSiteEmptyPost", new {name = name});
            }
          
            return View(profileView.ToList());
        }

        public ActionResult ProfileSiteEmptyPost(string name)
        {
            var profile = from p in _db.Users where p.UserName == name select p;

            if (!profile.Any())
            {
                return RedirectToAction("ErroResult", "Search");

            }

            return View(profile);
        }


        public ActionResult ProfileOptions()
        {
            return View();
        }

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

        public FileContentResult UserPhotos(string name)
        {
            if (name == null)
            {
                string fileName = HttpContext.Server.MapPath(@"~/Content/Image/noImage.png");

                FileInfo fileInfo = new FileInfo(fileName);
                long imageFileLength = fileInfo.Length;
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                var imageData = br.ReadBytes((int) imageFileLength);

                return File(imageData, "image/png");
            }

            // to get the user details to load user Image 
            var bdUsers = HttpContext.GetOwinContext().Get<ApplicationDbContext>();
            var userImage = bdUsers.Users.FirstOrDefault(x => x.UserName == name);

            return new FileContentResult(userImage.UserPhoto, "image/jpeg");
        }
    }
}