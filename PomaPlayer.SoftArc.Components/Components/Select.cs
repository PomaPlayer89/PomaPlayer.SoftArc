using Microsoft.AspNetCore.Mvc;
using PomaPlayer.SoftArc.Components.ViewModels;

namespace PomaPlayer.SoftArc.Components.Components;

public sealed class Select : ViewComponent
{
    public IViewComponentResult Invoke(SelectViewModel model)
    {
        return View("SelectView", model);
    }
}
