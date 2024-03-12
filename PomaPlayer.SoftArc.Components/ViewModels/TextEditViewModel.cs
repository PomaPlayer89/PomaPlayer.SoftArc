using Microsoft.AspNetCore.Html;

namespace PomaPlayer.SoftArc.Components.ViewModels;

public sealed record TextEditViewModel
{
    public bool HideRow { get; init; } = false;
    public bool LabelShow { get; init; } = true;
    public string DivClass { get; init; }
    public string InfoText { get; init; }
    public IHtmlContent Label { get; init; }
    public IHtmlContent Hidden { get; init; }
    public IHtmlContent TextBox { get; init; }
    public IHtmlContent ValidationMessage { get; init; }
}
