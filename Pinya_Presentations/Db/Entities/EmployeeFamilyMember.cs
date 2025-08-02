namespace Pinya_Presentations.Db;

public class EmployeeFamilyMember
{
    public int Id { get; set; }
    public PersonalName Name { get; set; } = new PersonalName();
    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
