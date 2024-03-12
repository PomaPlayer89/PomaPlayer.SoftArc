using Microsoft.AspNetCore.Html;

namespace PomaPlayer.SoftArc.Components.ViewModels;

public sealed record SelectViewModel
{
    public bool HideRow { get; init; }
    public bool LabelShow { get; init; } = true;
    public string DivClass { get; init; }
    public string InfoText { get; init; }
    public IHtmlContent Label { get; init; }
    public IHtmlContent Select { get; init; }
    public IHtmlContent Hidden { get; init; }
    public IHtmlContent ValidationMessage { get; init; }
}
