using Microsoft.AspNetCore.Mvc;
using PomaPlayer.SoftArc.Web.Models;
using System.Diagnostics;

namespace PomaPlayer.SoftArc.Web.Controllers
{
    [Route("")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HomeController : BaseController
    {
        public const string Home = "Home";

        public HomeController()
        {

        }

        [HttpGet, Route("")]
        public ActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpGet(nameof(Error), Name = nameof(Error))]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
