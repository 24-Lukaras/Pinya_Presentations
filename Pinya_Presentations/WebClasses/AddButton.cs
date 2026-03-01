using Microsoft.AspNetCore.Html;
using System.Text.Encodings.Web;

namespace Pinya_Presentations;

public class AddButton : IHtmlContent
{
    public readonly string? _method;
    public AddButton(){}
    public AddButton(string method)
    {
        _method = method;
    }

    public void WriteTo(TextWriter writer, HtmlEncoder encoder)
    {
        string button;
        if (_method is null)
            button = $"""
                <button type="submit" class="btn btn-primary">
                    <i class="fa fa-plus"></i>
                    &nbsp; Přidat
                </button>
                """;
        else
            button = $"""
                <a onclick="{_method}" class="btn btn-primary">
                    <i class="fa fa-plus"></i>
                    &nbsp; Přidat
                </a>
                """;
        writer.WriteLine(button);
    }
}
