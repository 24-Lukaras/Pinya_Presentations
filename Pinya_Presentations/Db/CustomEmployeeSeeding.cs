using Bogus;

namespace Pinya_Presentations.Db;

public class CustomEmployeeSeeding : BackgroundService
{
    private readonly IServiceScopeFactory _scopeProvider;
    public CustomEmployeeSeeding(IServiceScopeFactory scopeProvider)
    {
        _scopeProvider = scopeProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using (var scope = _scopeProvider.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<Database>();

            int totalEmployees = db.Employees.Count();

            if (totalEmployees > 0)
                return;

            var nameFaker = new NameFaker();
            var employeeFaker = new Faker<Employee>()
                .RuleFor(x => x.Name, f => nameFaker.Generate())
                .RuleFor(x => x.Email, f => f.Internet.Email());

            
            for (int i = 0; i < 10; i++)
            {
                var employee = employeeFaker.Generate();
                await db.AddAsync(employee);
            }

            await db.SaveChangesAsync();
        }
    }
}

public class NameFaker : Faker<PersonalName>
{
    private readonly string[] _degrees = { "Bc.", "Mgr.", "Ing.", "Ph.D.", "JUDr.", "RNDr." };
    private readonly string[] _degreesBehind = { "BS", "BA", "MA", "PhD", "MD" };
    public NameFaker()
    {
        UseSeed(420)
            .RuleFor(x => x.Firstname, f => f.Name.FirstName())
            .RuleFor(x => x.Lastname, f => f.Name.LastName())
            .RuleFor(x => x.Middlename, f => f.Random.Int(0, 100) > 60 ? f.Name.FirstName() : null)
            .RuleFor(x => x.Degrees, f => f.Random.Int(0, 100) > 70 ? f.PickRandom(_degrees) : null)
            .RuleFor(x => x.DegreesBehind, f => f.Random.Int(0, 100) > 90 ? f.PickRandom(_degreesBehind) : null);
    }
}
