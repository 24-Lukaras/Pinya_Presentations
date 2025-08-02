namespace Pinya_Presentations.Db;

public class EmployeeFamilyMember
{
    public int Id { get; set; }
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    public string Name => $"{Firstname} {Lastname}";
    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
