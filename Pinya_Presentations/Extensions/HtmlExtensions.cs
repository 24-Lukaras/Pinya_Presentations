using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Encodings.Web;

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

    public static HtmlLayoutBuilder<T> Layout<T>(this IHtmlHelper<T> html) =>
        new HtmlLayoutBuilder<T>(html);
}

public class HtmlLayoutBuilder<T>(IHtmlHelper<T> html)
{
    public HtmlColumnsBuilder<T> Columns(ColumnsLayout layout) =>
        new HtmlColumnsBuilder<T>(html, layout);
    public HtmlRowsBuilder<T> Rows() =>
        new HtmlRowsBuilder<T>(html);
}
public class HtmlColumnsBuilder<T>(IHtmlHelper<T> html, ColumnsLayout defaultLayout) : IHtmlContent
{
    private List<Func<object, object>> _columns = new List<Func<object, object>>();
    private ColumnsLayout? _phonePortrait;
    private ColumnsLayout? _phoneLandscape;
    private ColumnsLayout? _tablet;
    private ColumnsLayout? _desktop;
    public HtmlColumnsBuilder<T> PhoneVertical(ColumnsLayout layout)
    {
        _phonePortrait = layout;
        return this;
    }
    public HtmlColumnsBuilder<T> PhoneLandscape(ColumnsLayout layout)
    {
        _phoneLandscape = layout;
        return this;
    }
    public HtmlColumnsBuilder<T> Tablet(ColumnsLayout layout)
    {
        _tablet = layout;
        return this;
    }
    public HtmlColumnsBuilder<T> Desktop(ColumnsLayout layout)
    {
        _desktop = layout;
        return this;
    }
    public HtmlColumnsBuilder<T> AddColumn(Func<object, object> content)
    {
        _columns.Add(content);
        return this;
    }
    public void WriteTo(TextWriter writer, HtmlEncoder encoder)
    {
        var classes = GetClasses();   
        foreach (var column in _columns)
        {
            writer.Write($"<div class='{classes}'>");            
            object obj = column(null!);
            if (obj is HelperResult helperResult)
            {
                helperResult.WriteTo(writer, encoder);
            }
            else if (obj != null)
            {
                writer.Write(obj.ToString());
            }            
            writer.Write("</div>");
        }
    }
    private string GetClasses()
    {
        List<string> classes = new List<string>();
        classes.Add($"col-{GetLayoutUnits(_phonePortrait)}");
        classes.Add($"col-sm-{GetLayoutUnits(_phoneLandscape)}");
        classes.Add($"col-md-{GetLayoutUnits(_tablet)}");
        classes.Add($"col-lg-{GetLayoutUnits(_desktop)}");
        return string.Join(" ", classes);
    }
    private string GetLayoutUnits(ColumnsLayout? layout) =>
        (layout ?? defaultLayout) switch
        {
            ColumnsLayout.Single => "12",
            ColumnsLayout.Double => "6",
            ColumnsLayout.Triple => "4",
            _ => throw new NotSupportedException(),
        };
}
public class HtmlRowsBuilder<T>(IHtmlHelper<T> html)
{ }
public enum ColumnsLayout
{
    Single,
    Double,
    Triple,
}
