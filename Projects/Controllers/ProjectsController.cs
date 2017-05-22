using Projects.Context;
using System.Web.Mvc;

namespace Projects.Server.Controllers
{
    public class ProjectsController : BaseController
    {
        [HttpGet]
        public ActionResult Index(string name = null, string customer = null, string constructor = null, int? priority = null)
        {
            var result = _projects.Filter(name, customer, constructor, priority);

            return View(result);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var project = new Project();

            project = _projects.Add(project);
            ViewBag.AllWorkers = _workers.GetAll();

            return View(_editAction, project);
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var model = _projects.Find(id);

            if (null == model)
            {
                return RedirectNotFound();
            }

            ViewBag.AllWorkers = _workers.GetAll();

            return View(model);
        }
        [HttpGet]
        public ActionResult Details(long id)
        {
            var model = _projects.Find(id);

            if (null == model)
            {
                return RedirectNotFound();
            }

            return View(model);
        }
        [HttpGet]
        public ActionResult Remove(long id)
        {
            if (null == _projects.Find(id))
            {
                return RedirectNotFound();
            }

            _projects.Remove(id);

            return RedirectIndex();
        }

        [HttpPost]
        public ActionResult Update(Project project)
        {
            _projects.Update(project);

            return RedirectIndex();
        }
    }
}