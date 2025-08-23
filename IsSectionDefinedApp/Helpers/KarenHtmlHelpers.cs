using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IsSectionDefinedApp.Helpers;

public static class KarenHtmlHelpers
{
    public static IHtmlContent CreatedBy(this IHtmlHelper htmlHelper)
        => new HtmlString(
            """
            <div style="text-align: center;">
                Created by<strong>Karen Payne</strong>
            </div>
            """);

    public static IHtmlContent CreatedByFooter(this IHtmlHelper htmlHelper)
        => new HtmlString(
            """
            <span style="margin-left: 5px;">
            by <strong>Karen Payne</strong>
            </span>
            """);
}