namespace Pinya_Presentations.Settings;

public class EmailSettings
{
    public string SendGridApiKey { get; init; } = null!;
    public string Sender { get; init; } = null!;
    public string Receiver { get; init; } = null!;
}
