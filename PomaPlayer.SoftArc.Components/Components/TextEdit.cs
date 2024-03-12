using Microsoft.AspNetCore.Mvc;
using PomaPlayer.SoftArc.Components.ViewModels;

namespace PomaPlayer.SoftArc.Components.Components;

public sealed class TextEdit : ViewComponent
{
    public IViewComponentResult Invoke(TextEditViewModel model)
    {
        return View("TextEditView", model);
    }
}
