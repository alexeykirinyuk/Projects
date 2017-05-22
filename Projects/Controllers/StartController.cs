using System.Web.Mvc;

namespace Projects.Server.Controllers
{
    public class StartController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}