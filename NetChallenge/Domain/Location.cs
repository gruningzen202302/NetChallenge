using System.Collections;
using System.Collections.Generic;

namespace NetChallenge.Domain
{
    public class Location:EntityBase
    {
        public string Name { get; set; }
        public string Neighborhood { get; set; }

        public virtual ICollection<Office> Offices { get; set; }
    }
}