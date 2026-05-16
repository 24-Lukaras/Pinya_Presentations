namespace Pinya_Presentations.Services.Navigation;

public interface INavigationItem
{
    public string Title { get; }
    public string Url { get; }
    public string? Category { get; }
    public int Order { get; }
    public bool Visible { get; }
}
