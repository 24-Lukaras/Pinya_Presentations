using Pinya_Presentations.Orders.Application.Dto;
using Pinya_Presentations.Orders.Domain;

namespace Pinya_Presentations.Orders.Web.Model;

public class OrderGridModel
{
    public Guid Id { get; init; }
    public string Customer { get; init; }
    public OrderStatus Status { get; init; }
    public DateTime CreatedAtUtc { get; init; }

    public static OrderGridModel FromDto(BriefOrderDto dto) =>
        new OrderGridModel()
        {
            Id = dto.Id,
            Customer = dto.Customer,
            Status = dto.Status,
            CreatedAtUtc = dto.CreatedAtUtc,
        };
}
