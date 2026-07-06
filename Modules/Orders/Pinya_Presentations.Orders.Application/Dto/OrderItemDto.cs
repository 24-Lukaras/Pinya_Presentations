using Pinya_Presentations.Orders.Domain;

namespace Pinya_Presentations.Orders.Application.Dto;

public class OrderItemDto
{
    public Guid ProductId { get; init; }
    public string ProductName { get; init; }
    public int Amount { get; init; }

    public static OrderItemDto FromEntity(OrderItem entity) =>
        new OrderItemDto()
        {
            ProductId = entity.ProductId,
            ProductName = entity.ProductName,
            Amount = entity.Amount
        };
}
