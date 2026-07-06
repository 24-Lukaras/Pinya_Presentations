using Pinya_Presentations.Orders.Application.Dto;
using System.ComponentModel.DataAnnotations;

namespace Pinya_Presentations.Models;

public class OrderDetailModel
{
    public Guid Id { get; init; }

    public OrderDetailDataModel Data { get; init; }

    public IReadOnlyCollection<OrderItemDetailModel> Items { get; init; }

    public static OrderDetailModel FromDto(OrderDto dto) =>
        new OrderDetailModel()
        {
            Id = dto.Id,
            Data = new OrderDetailDataModel() { 
                Customer = dto.Customer,
                Status = dto.Status.ToText(),
                CreatedAtUtc = dto.CreatedAtUtc,
            },
            Items = dto.Items.Select(x => new OrderItemDetailModel()
            {
                ProductId = x.ProductId,
                Title = x.ProductName,
                Amount = x.Amount,
            }).ToArray()
        };
}
public class OrderDetailDataModel
{
    [Display(Name = "Zákazník")]
    public string Customer { get; init; }

    [Display(Name = "Stav")]
    public string Status { get; init; }

    [Display(Name = "Vytvořeno")]
    public DateTime CreatedAtUtc { get; init; }
}

public class OrderItemDetailModel
{
    public Guid ProductId { get; init; }
    public string Title { get; init; }
    public int Amount { get; init; }
}
