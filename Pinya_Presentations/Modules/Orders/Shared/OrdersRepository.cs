using Bogus;
using Pinya_Presentations.Domain;

namespace Pinya_Presentations.Modules.Orders.Shared;

public class OrdersRepository
{
    private static IEnumerable<Order>? _orders;

    public IEnumerable<Order> GetByStatus(OrderStatus status) =>
        GetAll().Where(x => x.Status == status);
    public Order? GetById(Guid id) => GetAll().FirstOrDefault(x => x.Id == id);
    public void Save() { }

    private IEnumerable<Order> GetAll()
    {
        if (_orders == null)
        {
            _orders = InitOrders();
        }
        return _orders;
    }    
    private IEnumerable<Order> InitOrders()
    {
        var itemFaker = new Faker<OrderItem>()
            .RuleFor(x => x.Name, f => f.Commerce.Product())
            .RuleFor(x => x.Amount, f => f.Random.Int(1, 15))
            .UseSeed(69);

        var faker = new Faker<Order>()
            .RuleFor(x => x.Id, f => f.Random.Guid())
            .RuleFor(x => x.Company, f => f.Company.CompanyName())
            .RuleFor(x => x.Status, f => f.PickRandom<OrderStatus>())
            .RuleFor(x => x.CompletedAtUtc, (f, order) => order.Status == OrderStatus.Completed ? f.Date.Recent(5) : null)
            .RuleFor(x => x.Items, f => itemFaker.GenerateBetween(1, 5))
            .UseSeed("penis".Length);

        return faker.Generate(50);
    }
}
