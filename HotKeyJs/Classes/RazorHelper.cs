using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotKeyJs.Classes;

public static class RazorHelper
{
    public static HelperResult DebugTable<TItem>(this IEnumerable<TItem> items)
    {
        var helperResult = new HelperResult(async writer =>
        {
            var firstItem = items.FirstOrDefault();

            await writer.WriteAsync("<table>");
            await writer.WriteAsync("<tr>");

            if (firstItem == null)
            {
                return;
            }

            var properties = firstItem.GetType().GetProperties();

            foreach (var property in properties)
            {
                await writer.WriteAsync("<td>" + property.Name + "</td>");
            }
            await writer.WriteAsync("</tr>");

            foreach (var item in items)
            {
                await writer.WriteAsync("<tr>");

                foreach (var property in properties)
                {
                    await writer.WriteAsync("<td>" + property.GetValue(item) + "</td>");
                }

                await writer.WriteAsync("</tr>");
            }

            await writer.WriteAsync("</table>");

        });

        return helperResult;
    }

    public static HelperResult DebugTable<TItem>(this IEnumerable<TItem> items, Func<TItem, HelperResult> template)
    {
    
        return new HelperResult(async writer =>
            {
                var firstItem = items.FirstOrDefault();

                if (firstItem == null)
                {
                    return;
                }

                await writer.WriteAsync("<table>");
                await writer.WriteAsync("<tr>");

                var properties = firstItem.GetType().GetProperties();

                foreach (var property in properties)
                {
                    await writer.WriteAsync("<td>" + property.Name + "</td>");
                }
                await writer.WriteAsync("</tr>");

                foreach (var item in items)
                {
                    foreach (var property in properties)
                    {
                        var result = template(item);
                        result.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);
                    }
                }
            }
        );
    }



    public static HelperResult Ellipsis(this IHtmlHelper helper, string text, int ellipsisLength = 150)
    {
        return new HelperResult(async writer =>
        {
            if (text.Length <= ellipsisLength)
            {
                await writer.WriteAsync(text);
            }
            else
            {
                await writer.WriteAsync("<span title='" + text + "'>");
                await writer.WriteAsync(text.Substring(0, ellipsisLength) + "...");
                await writer.WriteAsync("</span>");
            }
        });
    }


}
