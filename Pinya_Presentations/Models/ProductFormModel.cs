using Pinya_Presentations.Products.Dto;
using System.ComponentModel.DataAnnotations;

namespace Pinya_Presentations.Models;

public class ProductFormModel
{
    public ProductDetailModel Detail { get; init; }
    public ProductUpdateModel Changes { get; init; }

    public static ProductFormModel FromDto(ProductDto dto) =>
        new ProductFormModel()
        {
            Detail = new ProductDetailModel()
            {
                Id = dto.Id,
                Title = dto.Title,
                Amount = dto.Amount,
                ReservedAmount = dto.ReservedAmount,
                AvailableAmount = dto.AvailableAmount,
                CreatedAtUtc = dto.CreatedAtUtc,
            },
            Changes = new ProductUpdateModel()
        };
}
public class ProductDetailModel
{
    public Guid Id { get; init; }

    [Display(Name = "Název")]
    public string Title { get; init; }

    [Display(Name = "Množství")]
    public int Amount { get; init; }

    [Display(Name = "Rezervováno")]
    public int ReservedAmount { get; init; }

    [Display(Name = "Dostupné")]
    public int AvailableAmount { get; init; }

    [Display(Name = "Vytvořeno")]
    public DateTime CreatedAtUtc { get; init; }
}
public class ProductUpdateModel
{
    [Display(Name = "Množství")]
    [Range(1, int.MaxValue)]
    public int Amount { get; init; }
}