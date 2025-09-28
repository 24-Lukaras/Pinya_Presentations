using Pinya_Presentations.Models;

namespace Pinya_Presentations.Services;

public class ChatRoomService
{
    private List<ChatMessage> _messages = new List<ChatMessage>();

    public ChatMessage AddMessage(string message, string username)
    {
        var chatMessage = new ChatMessage(message, username, DateTime.UtcNow);
        _messages.Add(chatMessage);
        return chatMessage;
    }

    public IEnumerable<ChatMessage> GetAllMessagesOrdered() =>
        _messages.OrderBy(x => x.SentAtUtc).ToArray();
}
