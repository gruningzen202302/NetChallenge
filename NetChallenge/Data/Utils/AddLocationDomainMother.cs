using NetChallenge.Domain;

namespace NetChallenge.Data.Utils;
public static class AddLocationDomainMother
{
    public static Location Default => new Location { Name = "Location Default", Neighborhood = "Neighborhood Default" };
    public static Location Central => Default.WithName("Central").WithNeighborhood("Almagro");
    public static Location Almagro => Default.WithName("Sucursal Almagro 2").WithNeighborhood("Almagro");
    public static Location Palermo => Default.WithName("Sucursal Palermo").WithNeighborhood("Palermo");

    public static Location WithName(this Location location, string name)
    {
        location.Name = name;
        return location;
    }

    public static Location WithNeighborhood(this Location location, string neighborhood)
    {
        location.Neighborhood = neighborhood;
        return location;
    }
}
