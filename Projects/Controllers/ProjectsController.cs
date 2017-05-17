using Projects.DataTypes;
using Projects.Managers;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Projects.Server.Controllers
{
    public class ProjectsController : Controller
    {
        public ActionResult Index() => View();

        public IEnumerable<Project> GetAll() => new ProjectsManager().GetAll();

    }
}