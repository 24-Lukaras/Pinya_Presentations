namespace Pinya_Presentations.Db;

public class Employee
{
    public int Id { get; set; }
    public PersonalName Name { get; set; } = new PersonalName();
    public string? Email { get; set; }

    public virtual ICollection<EmployeeFamilyMember> EmployeeFamilyMembers { get; set; } = new List<EmployeeFamilyMember>();
}
