using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pinya_Presentations;

public static class HtmlExtensions
{
    public static IHtmlContent PropertiesOfModel<T>(this IHtmlHelper<T> html)
    {
        HtmlContentBuilder builder = new HtmlContentBuilder();
        builder.AppendHtmlLine("<ul>");
        foreach (var property in typeof(T).GetProperties())
            builder.AppendHtmlLine($"<li>{property.Name}</li>");
        builder.AppendHtmlLine("</ul>");
        return builder;
    }
}
