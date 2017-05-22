using Projects.Context;
using System.Web.Mvc;

namespace Projects.Server.Controllers
{
    public class WorkersController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(_workers.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            var worker = new Worker();

            worker = _workers.Add(worker);

            return View(_editAction, worker);
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var worker = _workers.Find(id);

            if (null == worker)
            {
                return RedirectNotFound();
            }

            return View(worker);
        }
        [HttpGet]
        public ActionResult Details(long id)
        {
            var worker = _workers.Find(id);

            if (null == worker)
            {
                return RedirectNotFound();
            }

            return View(worker);
        }
        [HttpGet]
        public ActionResult Remove(long id)
        {
            if (null == _workers.Find(id))
            {
                return RedirectNotFound();
            }

            _projects.Remove(id);

            return RedirectIndex();
        }

        [HttpPost]
        public ActionResult Update(Worker worker)
        {
            _workers.Update(worker);

            return RedirectIndex();
        }
    }
}