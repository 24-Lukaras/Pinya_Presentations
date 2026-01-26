using Pinya_Presentations.Modules.Common;
using Pinya_Presentations.Modules.Sales.Shared;

namespace Pinya_Presentations.Modules.Sales;

public class GetSalesAmount : Slice<GetSalesAmountQuery, int>
{
    private readonly SalesAmountProvider _amount;
    public GetSalesAmount(SalesAmountProvider amount, ILogger<Slice<GetSalesAmountQuery, int>> logger) : base(logger)
    {
        _amount = amount;
    }

    protected override (string? Error, int Result) HandleInternal(GetSalesAmountQuery input) => (null, _amount.SalesAmount);

    protected override string? Validate(GetSalesAmountQuery input) => null;
}

public record GetSalesAmountQuery();
