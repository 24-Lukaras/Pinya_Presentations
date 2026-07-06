using Pinya_Presentations.Products.Domain;

namespace Pinya_Presentations.Products.Dto;

public class ProductDto
{
    public Guid Id { get; init; }
    public string Title { get; init; }
    public int Amount { get; init; }
    public int ReservedAmount { get; init; }
    public int AvailableAmount { get; init; }
    public DateTime CreatedAtUtc { get; init; }

    internal static ProductDto FromEntity(Product entity) =>
        new ProductDto()
        {
            Id = entity.Id,
            Title = entity.Title,
            Amount = entity.Amount,
            ReservedAmount = entity.ReservedAmount,
            AvailableAmount = entity.AvailableAmount,
            CreatedAtUtc = entity.CreatedAtUtc,
        };
}
