namespace Pinya_Presentations.Db.Model;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<Milestone> Milestones { get; set; } = new List<Milestone>();

}
