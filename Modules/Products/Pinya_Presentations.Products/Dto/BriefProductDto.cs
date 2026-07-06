using Pinya_Presentations.Products.Domain;

namespace Pinya_Presentations.Products.Dto;

public class BriefProductDto
{
    public Guid Id { get; init; }
    public string Title { get; init; } = default!;

    internal static BriefProductDto FromEntity(Product product) =>
        new BriefProductDto()
        {
            Id = product.Id,
            Title = product.Title,
        };
}
