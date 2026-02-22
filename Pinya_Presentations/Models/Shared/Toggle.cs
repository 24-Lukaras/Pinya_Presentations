namespace Pinya_Presentations.Models;

public class Toggle
{
    public bool Checked { get; init; }

    public Toggle() { }
    public Toggle(bool @checked)
    {
        Checked = @checked;
    }
    public static implicit operator Toggle(bool @checked) => new Toggle(@checked);
    public static implicit operator bool(Toggle toggle) => toggle.Checked;
}
