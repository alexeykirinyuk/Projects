using System.Web.Mvc;

namespace MvcApi.Controllers
{
    public class ProjectsController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return default(ActionResult);
        }
    }
}
