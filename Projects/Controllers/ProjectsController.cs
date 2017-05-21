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

        [HttpGet]
        public ActionResult Edit(long id)
        {
            var model = new ProjectsManager().Find(id);

            if (null == model)
            {
                return View("NotFound");
            }

            return View(model);
        }
    }
}