using System.Collections;
using System.Collections.Generic;

namespace NetChallenge.Domain
{
    public class Office:EntityBase
    {
        public string LocationName { get; set; }
        public string Name { get; set; }
        public int MaxCapacity { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<Facility> Facilities { get; set; }
    }
}