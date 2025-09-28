using Microsoft.AspNetCore.SignalR;
using Pinya_Presentations.Models;
using Pinya_Presentations.Services;

namespace Pinya_Presentations.Hubs;

public class ChatHub : Hub
{
    public const string NEW_MESSAGE_EVENT = "NewMessage";

    private readonly ChatRoomService _service;
    public ChatHub(ChatRoomService service)
    {
        _service = service;
    }

    public async Task<ChatMessage?> SendMessage(string message)
    {
        string? username = Context.User?.Identity?.Name;

        if (username is null)
            return null;

        ChatMessage chatMessage = _service.AddMessage(message, username);
        await Clients.Others.SendAsync(NEW_MESSAGE_EVENT, chatMessage);
        return chatMessage;
    }
}

