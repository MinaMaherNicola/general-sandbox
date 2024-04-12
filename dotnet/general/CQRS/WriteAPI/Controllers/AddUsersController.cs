using System.Text.Json;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WriteAPI.Commands;
using WriteAPI.DataAccess.Models;

namespace WriteAPI.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class AddUsersController(IMediator mediator) : ControllerBase
{
    private readonly List<User> _users = JsonSerializer.Deserialize<List<User>>(@"[
      {
        ""id"": ""ad22febf-73e9-42f2-914e-0cf01a93df60"",
        ""isActive"": false,
        ""balance"": ""$3,545.11"",
        ""picture"": ""http://placehold.it/32x32"",
        ""age"": 24,
        ""name"": ""Price Richmond"",
        ""email"": ""pricerichmond@pyramia.com""
      },
      {
        ""id"": ""0a27f428-9b9f-449a-8232-4e3cabe22c3c"",
        ""isActive"": false,
        ""balance"": ""$2,897.41"",
        ""picture"": ""http://placehold.it/32x32"",
        ""age"": 23,
        ""name"": ""Erna Hammond"",
        ""email"": ""ernahammond@pyramia.com""
      },
      {
        ""id"": ""f1ef8f0c-f981-4388-b943-68d697f2f2b9"",
        ""isActive"": false,
        ""balance"": ""$1,165.85"",
        ""picture"": ""http://placehold.it/32x32"",
        ""age"": 29,
        ""name"": ""Sharpe Workman"",
        ""email"": ""sharpeworkman@pyramia.com""
      },
      {
        ""id"": ""741138d5-7a89-4872-a274-51c6a36e92e6"",
        ""isActive"": false,
        ""balance"": ""$1,745.24"",
        ""picture"": ""http://placehold.it/32x32"",
        ""age"": 37,
        ""name"": ""Miranda Wall"",
        ""email"": ""mirandawall@pyramia.com""
      },
      {
        ""id"": ""85f92bf8-f682-4eb0-94db-a768f48524cd"",
        ""isActive"": false,
        ""balance"": ""$1,232.45"",
        ""picture"": ""http://placehold.it/32x32"",
        ""age"": 36,
        ""name"": ""Huffman Rosa"",
        ""email"": ""huffmanrosa@pyramia.com""
      },
      {
        ""id"": ""4cdbae1c-3234-4f18-a92f-3b59142b69cf"",
        ""isActive"": true,
        ""balance"": ""$2,179.54"",
        ""picture"": ""http://placehold.it/32x32"",
        ""age"": 23,
        ""name"": ""Margie Alston"",
        ""email"": ""margiealston@pyramia.com""
      }
    ]", new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;
    
    [HttpGet]
    public async Task<IActionResult> Users()
    {
      try
      {
        await mediator.Send(new AddUsersCommand(_users));
        return Ok();
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
}