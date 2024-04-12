using System.ComponentModel.DataAnnotations;

namespace ReaderAPI.DataAccess.Models;

public class User
{
    public Guid Id { get; init; }
    public bool IsActive { get; set; }
    [StringLength(15)]
    public required string Balance { get; set; }
    public short Age { get; set; }
    [StringLength(50)]
    public required string Name { get; set; }
    [StringLength(100)]
    public required string Email { get; set; }
}