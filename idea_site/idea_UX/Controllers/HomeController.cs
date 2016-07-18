using idea_BLL.Model.User;
using System.Web.Mvc;

namespace idea_UX.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Register(User newUser)
        {
            JsonResult message = new JsonResult();

            return message;
        }
    }
}