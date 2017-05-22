using Projects.Context;
using Projects.Managers;
using System.Web.Mvc;

namespace Projects.Server.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IManager<Project> _projects = ManagerFactory.Get<Project>();
        private readonly IManager<Worker> _workers = ManagerFactory.Get<Worker>();

        private const string _notFound = "NotFound";
        private const string _indexAction = "Index";
        private const string _editAction = "Edit";

        [HttpGet]
        public ActionResult Index()
        {
            return View(_projects.GetAll());
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
                return View(_notFound);
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
                return View(_notFound);
            }

            return View(model);
        }
        [HttpGet]
        public ActionResult Remove(long id)
        {
            if (null == _projects.Find(id))
            {
                return View(_notFound);
            }

            _projects.Remove(id);

            return RedirectToAction(_indexAction);
        }

        [HttpPost]
        public ActionResult Update(Project project)
        {
            _projects.Update(project);

            return RedirectToAction(_indexAction);
        }
    }
}