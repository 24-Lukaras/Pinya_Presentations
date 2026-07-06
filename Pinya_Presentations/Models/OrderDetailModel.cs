using Pinya_Presentations.Orders.Application.Dto;
using System.ComponentModel.DataAnnotations;

namespace Pinya_Presentations.Models;

public class OrderDetailModel
{
    public Guid Id { get; init; }

    public OrderDetailDataModel Data { get; init; }

    public static OrderDetailModel FromDto(OrderDto dto) =>
        new OrderDetailModel()
        {
            Id = dto.Id,
            Data = new OrderDetailDataModel() { 
                Customer = dto.Customer,
                Status = dto.Status.ToText(),
                CreatedAtUtc = dto.CreatedAtUtc,
            }
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
