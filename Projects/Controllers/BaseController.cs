using Projects.Context;
using Projects.Managers;
using System.Web.Mvc;

namespace Projects.Server.Controllers
{
    public class BaseController : Controller
    {
        protected readonly ProjectsManager _projects = ManagerFactory.Get<Project>() as ProjectsManager;
        protected readonly WorkersManager _workers = ManagerFactory.Get<Worker>() as WorkersManager;

        protected const string _editAction = "Edit";

        public ActionResult RedirectNotFound()
        {
            return RedirectToAction("NotFound");
        }
        public ActionResult RedirectIndex()
        {
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult NotFound()
        {
            return View();
        }
    }
}