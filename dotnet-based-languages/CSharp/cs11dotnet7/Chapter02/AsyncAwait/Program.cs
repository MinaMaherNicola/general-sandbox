internal class Program
{
  private static async Task Main(string[] args)
  {
    HttpClient httpClient = new();

    var response = await httpClient.GetAsync("https://www.apple.com");

    Console.WriteLine(response.Content.Headers.ContentLength);
  }
}