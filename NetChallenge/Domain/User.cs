namespace NetChallenge.Domain;

public class User : EntityBase
{
    public string Name { get; set; }

    //TODO consider public string Email {get; set;} if an extra key value is needed (other than the inhereted Id)
}