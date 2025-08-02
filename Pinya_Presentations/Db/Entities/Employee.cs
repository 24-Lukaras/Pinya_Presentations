namespace Pinya_Presentations.Db;

public class Employee
{
    public int Id { get; set; }
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    public string Name => $"{Firstname} {Lastname}";
    public string? Email { get; set; }

    public virtual ICollection<EmployeeFamilyMember> EmployeeFamilyMembers { get; set; } = new List<EmployeeFamilyMember>();
}
