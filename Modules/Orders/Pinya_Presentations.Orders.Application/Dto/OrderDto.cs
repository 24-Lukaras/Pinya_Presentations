using Pinya_Presentations.Orders.Domain;

namespace Pinya_Presentations.Orders.Application.Dto;

public class OrderDto
{
    public Guid Id { get; init; }
    public OrderStatus Status { get; init; }
    public string Customer { get; init; }
    public DateTime CreatedAtUtc { get; init; }
    public IReadOnlyCollection<OrderItemDto> Items { get; init; }

    public static OrderDto FromEntity(Order order) =>
        new OrderDto()
        {
            Id = order.Id,
            Status = order.Status,
            Customer = order.Customer,
            CreatedAtUtc = order.CreatedAtUtc,
            Items = order.Items.Select(OrderItemDto.FromEntity).ToList()
        };
}
