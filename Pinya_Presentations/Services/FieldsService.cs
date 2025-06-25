namespace Pinya_Presentations.Services;

public class FieldsService
{
    private static IEnumerable<Field> _fields =>
        new List<Field>()
        {
            new Field(1, FieldType.Country, "CZ"),
            new Field(2, FieldType.Country, "SK"),
            new Field(3, FieldType.Country, "PL"),
            new Field(4, FieldType.Country, "UK"),
            new Field(5, FieldType.Country, "USA"),

            new Field(10, FieldType.Company, "Pinya s.r.o."),
            new Field(11, FieldType.Company, "Business Lease s.r.o."),

            new Field(20, FieldType.Department, "Finance"),
            new Field(21, FieldType.Department, "Human Resources"),
            new Field(22, FieldType.Department, "Development"),
        };

    public async Task<IEnumerable<Field>> GetFields()
    {
        await Task.Delay(3000);
        return _fields;
    }
}

public class Field
{
    public int Id { get; init; }
    public FieldType Type { get; private set; }
    public string Title { get; private set; }

    public Field(int id, FieldType type, string title)
    {
        Id = id;
        Type = type;
        Title = title;
    }
}

public enum FieldType
{
    Country,
    Company,
    Department,
}
