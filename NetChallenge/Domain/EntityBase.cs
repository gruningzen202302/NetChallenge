using System.ComponentModel.DataAnnotations;

namespace NetChallenge.Domain;

public class EntityBase
{
    [Key] public int Id { get; set; }
}