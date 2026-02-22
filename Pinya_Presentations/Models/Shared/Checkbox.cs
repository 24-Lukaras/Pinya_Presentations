namespace Pinya_Presentations.Models;

public class Checkbox
{
    public bool Checked { get; init; }

    public Checkbox() { }
    public Checkbox(bool @checked)
    {
        Checked = @checked;
    }
    public static implicit operator Checkbox(bool @checked) => new Checkbox(@checked);
    public static implicit operator bool(Checkbox checkbox) => checkbox.Checked;
}
