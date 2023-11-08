using System.Collections;

namespace NetChallenge.Domain
{
    public class Office:EntityBase
    {
        public string LocationName { get; set; }
        public string Name { get; set; }
        public int MaxCapacity { get; set; }
        //public ICollection<string> AvailableResources { get; set; }
    }
}