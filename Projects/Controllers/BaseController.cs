using Projects.Context;
using Projects.Managers;
using System.Web.Mvc;

namespace Projects.Server.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IManager<Project> _projects = ManagerFactory.Get<Project>();
        protected readonly IManager<Worker> _workers = ManagerFactory.Get<Worker>();

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