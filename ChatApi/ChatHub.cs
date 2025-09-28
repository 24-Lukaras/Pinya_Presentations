using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

namespace ChatApi;

public class ChatHub : Hub
{
    private static ConcurrentDictionary<string, string> _users = new();
    private static ConcurrentDictionary<string, string> _userGroups = new();
    private const string MESSAGE_RECEIVED_EVENT = "MessageReceived";

    public async Task Login(string username)
    {
        _users[Context.ConnectionId] = username;
        await Clients.AllExcept(Context.ConnectionId).SendAsync(MESSAGE_RECEIVED_EVENT, $"{username} has connected");
    }

    public async Task JoinLobby(string lobbyName)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, lobbyName);
        _userGroups[Context.ConnectionId] = lobbyName;
        await Clients.GroupExcept(lobbyName, Context.ConnectionId).SendAsync(MESSAGE_RECEIVED_EVENT, $"{_users[Context.ConnectionId]} has connected to lobby {lobbyName}");
    }

    public async Task SendMessage(string message)
    {
        if (_userGroups.TryGetValue(Context.ConnectionId, out string? lobbyName))
        {
            await Clients.GroupExcept(lobbyName, Context.ConnectionId).SendAsync(MESSAGE_RECEIVED_EVENT, $"{_users[Context.ConnectionId]} says: {message}");
        }
        else
        {
            await Clients.AllExcept(Context.ConnectionId).SendAsync(MESSAGE_RECEIVED_EVENT, $"{_users[Context.ConnectionId]} says: {message}");
        }
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await Clients.AllExcept(Context.ConnectionId).SendAsync(MESSAGE_RECEIVED_EVENT, $"{_users[Context.ConnectionId]} has disconnected");
        _users.Remove(Context.ConnectionId, out _);
        await base.OnDisconnectedAsync(exception);
    }
}
