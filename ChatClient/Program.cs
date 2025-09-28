// See https://aka.ms/new-console-template for more information

using Microsoft.AspNetCore.SignalR.Client;


bool useLobbies = false;
string url = "https://localhost:7143/Chat";
var connection = new HubConnectionBuilder()
    .WithUrl(url)
    .Build();

connection.On<string>("MessageReceived", (message) => Console.WriteLine(message));


Console.WriteLine("Enter username:");
var username = Console.ReadLine();

await connection.StartAsync();
await connection.InvokeAsync("Login", username);

if (useLobbies)
{
    Console.WriteLine("Enter lobby name:");
    var lobby = Console.ReadLine();
    await connection.InvokeAsync("JoinLobby", lobby);
}

string? message = string.Empty;
do
{
    message = Console.ReadLine();

    if (!string.IsNullOrEmpty(message))
    {
        await connection.InvokeAsync("SendMessage", message);
    }

} while (!string.IsNullOrEmpty(message));

await connection.StopAsync();


