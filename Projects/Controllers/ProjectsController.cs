using Projects.Managers;
using System.Web.Mvc;

namespace Projects.Server.Controllers
{
    public class ProjectsController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var manager = new ProjectsManager();

            return View(manager.GetAll());
        }
    }
}