using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Pinya_Presentations.TagHelpers;

[HtmlTargetElement("form-icon", TagStructure = TagStructure.NormalOrSelfClosing, Attributes = "kind")]
public class FormIconTagHelper : TagHelper
{
    public FormIconKind Kind { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "i";
        output.Attributes.Clear();
        output.TagMode = TagMode.StartTagAndEndTag;
        var iconClass = GetIconClass();
        if (string.IsNullOrEmpty(iconClass))
        {
            output.SuppressOutput();
            return;
        }    
        output.Attributes.Add("class", iconClass);
    }
    private string? GetIconClass() =>
        Kind switch
        {
            FormIconKind.Save => "fa fa-save",
            //FormIconKind.Save => "fa fa-check",
            FormIconKind.Cancel => "fa fa-ban",
            //FormIconKind.Cancel => "fa fa-times",
            FormIconKind.Delete => "fa fa-trash",
            _ => null
        };
}
public enum FormIconKind
{
    Save,
    Cancel,
    Delete,
}
