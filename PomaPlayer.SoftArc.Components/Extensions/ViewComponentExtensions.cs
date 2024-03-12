using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PomaPlayer.SoftArc.Components.Components;
using PomaPlayer.SoftArc.Components.Constants;
using PomaPlayer.SoftArc.Components.ViewModels;
using System.Linq.Expressions;

namespace PomaPlayer.SoftArc.Components.Extensions;

/// <summary>
/// todo: можно переработать и загнать в cshtml.
/// </summary>
public static class ViewComponentExtensions
{
    private const string MaskAttr = "data-mask";

    public static async Task<IHtmlContent> SelectAsync<TModel, TItem>(this IViewComponentHelper viewComponentHelper,
        IHtmlHelper<TModel> html, Expression<Func<TModel, TItem>> expr, IEnumerable<SelectListItem> selectList,
        string divClass = "", bool hideRow = false, bool readOnly = false, bool isLabel = true,
        Dictionary<string, object> selectHtmlAttr = null, string infoText = null)
    {
        var labelHtmlAttr = new Dictionary<string, object>
        {
            { "class",  Bootstrap.FormLabel }
        };

        selectHtmlAttr ??= new Dictionary<string, object>();
        selectHtmlAttr.Add("class", Bootstrap.FormSelect);

        if (readOnly)
            selectHtmlAttr.Add(Bootstrap.Disabled, Bootstrap.Disabled);

        var model = new SelectViewModel()
        {
            Label = html.LabelFor(expr, labelHtmlAttr),
            Select = html.DropDownListFor(expr, selectList, selectHtmlAttr),
            ValidationMessage = html.ValidationMessageFor(expr),
            DivClass = divClass,
            HideRow = hideRow,
            Hidden = readOnly ? html.HiddenFor(expr) : null,
            LabelShow = isLabel,
            InfoText = infoText
        };

        return await viewComponentHelper.InvokeAsync(typeof(Select), model);
    }

    public static async Task<IHtmlContent> TextAsync<TModel, TItem>(this IViewComponentHelper viewComponentHelper,
        IHtmlHelper<TModel> html, Expression<Func<TModel, TItem>> expr, string divClass = "", string placeholder = "",
        string infoText = "", bool hideRow = false, bool readOnly = false, bool isLabel = true)
    {
        var labelHtmlAttr = new Dictionary<string, object>
        {
            { "class", Bootstrap.FormLabel }
        };

        var textBoxHtmlAttr = new Dictionary<string, object>
        {
            { "class", Bootstrap.FormControl },
            { "placeholder", placeholder }
        };

        if (readOnly)
            textBoxHtmlAttr.Add(Bootstrap.Disabled, Bootstrap.Disabled);

        var model = new TextEditViewModel()
        {
            Label = html.LabelFor(expr, labelHtmlAttr),
            TextBox = html.TextBoxFor(expr, textBoxHtmlAttr),
            ValidationMessage = html.ValidationMessageFor(expr),
            DivClass = divClass,
            InfoText = infoText,
            HideRow = hideRow,
            Hidden = readOnly ? html.HiddenFor(expr) : null,
            LabelShow = isLabel
        };

        return await viewComponentHelper.InvokeAsync(typeof(TextEdit), model);
    }
}
