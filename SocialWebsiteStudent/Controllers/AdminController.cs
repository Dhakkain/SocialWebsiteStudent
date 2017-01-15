using System.Threading.Tasks;
using System.Web.Mvc;
using SocialWebsiteStudent.Domain.Repository.Interface;

namespace SocialWebsiteStudent.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminRepository _repo;

        public AdminController(IAdminRepository repo)
        {
            _repo = repo;
        }

        [Authorize]
        public ActionResult DeletePost(int id)
        {
            //Find post in database
            var deletePost = _repo.GetPost(id);

            _repo.RemoveNotification(id);

            //Remove post and his comments from db
            _repo.RemovePost(deletePost);
            //Save
            _repo.SaveChanges();

            return RedirectToAction("WallPost", "Post");
        }

        [Authorize]
        public ActionResult DeleteComment(int id)
        {
            //Find post in database
            var deleteComment = _repo.GetComment(id);

            //Remove post and his comments from db
            _repo.RemoveComment(deleteComment);
            //Save
            _repo.SaveChanges();

            return RedirectToAction("WallPost", "Post");
        }

        [Authorize]
        public ActionResult BlockUser(string id)
        {
            var bannedUser = _repo.BlockUser(id);

            return RedirectToAction("BlockUserName", "Admin", new {username = bannedUser});
        }

        [Authorize]
        public ActionResult BlockUserName(string username)
        {
            _repo.BlockUsername(username);

            return RedirectToAction("ProfileSite", "User", new {name = username});
        }

        [Authorize]
        public async Task<ActionResult> UnblockUser(string username)
        {
            await _repo.UnblockUser(username);

            return RedirectToAction("ProfileSite", "User", new {name = username});
        }

        [Authorize]
        public ActionResult TakeAdminClaim(string username)
        {
           _repo.TakeAdmin(username);
            return RedirectToAction("ProfileSite", "User", new {name = username});
        }
    }
}