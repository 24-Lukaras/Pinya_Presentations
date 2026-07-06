using Pinya_Presentations.Orders.Domain;

namespace Pinya_Presentations.Orders.Application.Dto;

public class BriefOrderDto
{
    public Guid Id { get; init; }
    public string Customer { get; init; }
    public OrderStatus Status { get; init; }
    public DateTime CreatedAtUtc { get; init; }

    public static BriefOrderDto FromEntity(Order order) =>
        new BriefOrderDto()
        {
            Id = order.Id,
            Customer = order.Customer,
            Status = order.Status,
            CreatedAtUtc = order.CreatedAtUtc,
        };
}
