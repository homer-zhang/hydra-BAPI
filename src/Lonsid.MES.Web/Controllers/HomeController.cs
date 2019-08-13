using Microsoft.AspNetCore.Mvc;

namespace Lonsid.MES.Web.Controllers
{
    public class HomeController : MESControllerBase
    {
        public ActionResult Index()
        {
            return this.Redirect("/swagger");
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}