using System.ComponentModel.DataAnnotations;

namespace NetChallenge.Domain;

public class User : EntityBase
{
    public string Name { get; set; }
    public required string Email { get; set; }

}