using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SocialWebsiteStudent.Models;

namespace SocialWebsiteStudent.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // GET: User
        public ActionResult ProfileSite(string name)
        {
            var profileView = (from u in _db.Posts where u.ApplicationUser.UserName == name select u);

            return View(profileView.ToList());
        }

     
    }
}
