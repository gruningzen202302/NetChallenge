using System.ComponentModel.DataAnnotations;

namespace NetChallenge.Domain;

public class User : EntityBase
{
    public required string Name { get; set; }
    public string Email { get; set; }

}