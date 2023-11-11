namespace NetChallenge.Domain;

public class AvailableResource:EntityBase{
    public required string Name { get; set; }
    public int OfficeId { get; set; }
    public virtual Office Office { get; set; }
}