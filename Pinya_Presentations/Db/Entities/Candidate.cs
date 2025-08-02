namespace Pinya_Presentations.Db;

public class Candidate
{
    public int Id { get; set; }
    public PersonalName Name { get; set; } = new PersonalName();
}
