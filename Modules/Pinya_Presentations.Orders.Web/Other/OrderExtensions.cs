
using Pinya_Presentations.Orders.Domain;

namespace Pinya_Presentations;

public static class OrderExtensions
{
    public static string ToText(this OrderStatus status) =>
        status switch
        {
            OrderStatus.Created => "Vytvořeno",
            OrderStatus.Confirmed => "Potvrzeno",
            OrderStatus.Processed => "Dokončeno",
            _ => "N/A"
        };
}
