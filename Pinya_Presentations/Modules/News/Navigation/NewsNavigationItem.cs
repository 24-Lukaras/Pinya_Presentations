using Pinya_Presentations.Services.Navigation;

namespace Pinya_Presentations.Modules.News.Navigation;

public class NewsNavigationItem : INavigationItem
{
    public string Title => "Novinky";
    public string Url => "/News";
    public string? Category => null;
    public int Order => 0;
    public bool Visible => true;
}
