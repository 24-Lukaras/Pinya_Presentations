using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Pinya_Presentations.TagHelpers;

[HtmlTargetElement("item-card", TagStructure = TagStructure.WithoutEndTag)]
public class ItemCardTagHelper : TagHelper
{
    public string? ItemName { get; set; }
    public int Amount { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.SuppressOutput();
        if (string.IsNullOrEmpty(ItemName))
            return;
        output.Content.SetHtmlContent(GetContent(ItemName, Amount));
    }
    public static string GetContent(string title, int amount)
    {
        string amountText = amount > 0
            ? $"{amount}ks na skladě"
            : "nedostupné";
        return $$"""
            <div class="d-flex flex-column border border-black border-1 rounded-1 p-2">
                <b>{{title}}</b>
                <span class="align-self-end">{{amountText}}</span>
            </div>
            """;
    }
}
