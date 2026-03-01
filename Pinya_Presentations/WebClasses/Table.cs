using Microsoft.AspNetCore.Html;
using System.Reflection;
using System.Text.Encodings.Web;

namespace Pinya_Presentations;

public class Table<T> : IHtmlContent
{
    private readonly T[] _data;
    public Table(params T[] data)
    {
        _data = data;
    }
    public void WriteTo(TextWriter writer, HtmlEncoder encoder)
    {
        var properties = typeof(T).GetProperties();
        writer.WriteLine("<table>");
        CreateTableHeader(writer, properties);
        CreateTableContent(writer, properties);
        writer.WriteLine("</table>");
    }
    private void CreateTableHeader(TextWriter writer, IEnumerable<PropertyInfo> properties)
    {
        writer.WriteLine("<tr>");
        foreach (var property in properties)
            writer.WriteLine($"<th>{property.Name}</th>");
        writer.WriteLine("</tr>");
    }
    private void CreateTableContent(TextWriter writer, IEnumerable<PropertyInfo> properties)
    {
        foreach (var item in _data)
        {
            writer.WriteLine("<tr>");
            foreach (var property in properties)
                writer.WriteLine($"<td>{property.GetValue(item)}</td>");
            writer.WriteLine("</tr>");
        }
    }
}
