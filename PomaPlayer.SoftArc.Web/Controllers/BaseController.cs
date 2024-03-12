using Microsoft.AspNetCore.Mvc;

namespace PomaPlayer.SoftArc.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        public BaseController()
        {

        }

        // todo: нужен глобальный обработчик ошибок для методов контроллера, НО для упрощения без него
    }
}
