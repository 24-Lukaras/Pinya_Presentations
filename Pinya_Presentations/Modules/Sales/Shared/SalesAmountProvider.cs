namespace Pinya_Presentations.Modules.Sales.Shared;

public class SalesAmountProvider
{
    public int SalesAmount { get; private set; } = Random.Shared.Next(100, 201);

    public void Add(int amount)
    {
        if (amount > 0)
            SalesAmount += amount;
    }
}
