using Microsoft.AspNetCore.Mvc;

namespace MyNightDapper.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult AdminHeader()
        {
            return PartialView();
        }
        public PartialViewResult AdminHead()
        {
            return PartialView();
        }
        public PartialViewResult AdminSidebar()
        {
            return PartialView();
        }
        public PartialViewResult AdminNavbar()
        {
            return PartialView();
        }
        public PartialViewResult AdminFooter()
        {
            return PartialView();
        }
        public PartialViewResult AdminScript()
        {
            return PartialView();
        }
    }
}
