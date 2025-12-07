namespace EventSourcingData.Services;

public interface ILoggedUserProvider
{
    public string? Username { get; }
}
