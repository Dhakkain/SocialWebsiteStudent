using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SocialWebsiteStudent.Models;

namespace SocialWebsiteStudent.Controllers
{
    public class TagController : Controller
    {

        private readonly ApplicationDbContext _db = new ApplicationDbContext();


        // GET: Tag
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetTag(string term)
        {
            var tags = new List<string>()
            {
                (from t in _db.Tags select t).ToString()
            };

            IEnumerable<string> data;

            if (term != null)
            {
                data = tags.Where(x => x.StartsWith(term));
            }
            else
                data = tags;

            return Json(data, JsonRequestBehavior.AllowGet); 
        }

    }
}
