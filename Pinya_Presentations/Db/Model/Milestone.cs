namespace Pinya_Presentations.Db.Model;

public class Milestone
{
    public DateOnly EffectiveDateTime { get; set; }
    public string Company { get; set; } = null!;
    public string Location { get; set; } = null!;
}
