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
string username = await client.GetConnectionId() ?? throw new InvalidOperationException();
Console.WriteLine($"You're connected to the server with connection-id: {username}");
Console.WriteLine("-------------------------------------------");
Console.WriteLine("Type -h for help");
while (true)
{
    Console.Write($"{username}: ");
    string? input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input)) continue;

    if (input == "exit")
    {
        Console.WriteLine("Exiting the chat");
        await client.DisposeAsync();
        break;
    }

    if (input.StartsWith("-h", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine("1. type '-u username' to change your username");
        Console.WriteLine("1. type '-j room' to create/enter group");
    }
    else if (input.StartsWith("-u", StringComparison.OrdinalIgnoreCase) && input.Split(' ').Length > 1)
    {
        username = input.Split(' ')[1];
        await client.ChangeUsername(input);
    }
    else
    {
        await client.SendMessageAsync(input);
    }
}