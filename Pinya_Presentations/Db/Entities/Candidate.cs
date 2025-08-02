namespace Pinya_Presentations.Db;

public class Candidate
{
    public int Id { get; set; }
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    public string Name => $"{Firstname} {Lastname}";
}
