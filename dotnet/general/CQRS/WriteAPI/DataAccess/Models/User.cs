namespace WriteAPI.DataAccess.Models;

public class User
{
    public Guid Id { get; set; }
    public bool IsActive { get; set; }
    public required string Balance { get; set; }
    public uint Age { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
}