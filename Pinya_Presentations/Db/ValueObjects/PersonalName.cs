namespace Pinya_Presentations.Db;

public class PersonalName
{
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    public string? Middlename { get; set; }
    public string? Degrees { get; set; }
    public string? DegreesBehind { get; set; }

    public string FullName =>
        string.Join(" ",
            (new string?[] { Degrees, Firstname, Middlename, Lastname, DegreesBehind})
            .Where(x => !string.IsNullOrEmpty(x))
        );
    public string ListName => $"{Lastname} {Firstname}";
}
