using Chat.Client;
using Chat.Contract;

var client = new Client();
await client.StartAsync();


Console.WriteLine("Could not connect to the server, please wait.");
while (string.IsNullOrWhiteSpace(await client.GetConnectionId()))
{
    Console.WriteLine("Attempting to reconnect...");
    await client.DisposeAsync();
    client = new Client();
    await client.StartAsync();
}
Console.WriteLine($"You're connected to the server with connection-id: {await client.GetConnectionId()}");

while (true)
{
    string? input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input)) continue;

    if (input == "exit")
    {
        Console.WriteLine("Exiting the chat");
        await client.DisposeAsync();
        break;
    }

    await client.SendMessageAsync(input);
}