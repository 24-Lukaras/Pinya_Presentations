using Microsoft.AspNetCore.Razor.TagHelpers;
using Pinya_Presentations.Services.Items;

namespace Pinya_Presentations.TagHelpers;

[HtmlTargetElement("items-grid", TagStructure = TagStructure.NormalOrSelfClosing)]
public class ItemsGridTagHelper : TagHelper
{
    public Func<ItemsRepository, Task<IEnumerable<StorageItem>>>? Selector { get; set; }
    public int Columns { get; set; }

    private readonly ItemsRepository _repository;
    public ItemsGridTagHelper(ItemsRepository repository)
    {
        _repository = repository;
    }
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        Setup(output);
        if (Selector is null)
            return;
        var items = await Selector(_repository);
        output.Content.SetHtmlContent(string.Join("", items.Select(x => ItemCardTagHelper.GetContent(x.Title, x.Amount))));
    }
    private void Setup(TagHelperOutput output)
    {
        output.TagName = "div";
        output.Attributes.Add("class", $"d-grid gap-2");
        output.Attributes.Add("style", $"grid-template-columns: repeat({Columns}, auto)");
    }
}
