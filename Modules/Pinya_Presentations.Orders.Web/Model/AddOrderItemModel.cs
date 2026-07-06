using Microsoft.AspNetCore.Mvc;

namespace Pinya_Presentations.Orders.Web.Model;

public class AddOrderItemModel
{
    [FromRoute(Name = "id")]
    public Guid Id { get; init; }
    public Guid ProductId { get; init; }
    public int Amount { get; init; }
}
