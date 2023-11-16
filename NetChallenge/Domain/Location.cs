using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace NetChallenge.Domain
{
    public class Location:EntityBase
    {
        public required string Name { get; set; }
        public required string Neighborhood { get; set; }
        public  int Latitude { get; set; }
        public int Longitude { get; set; }
        public virtual ICollection<Office> Offices { get; set; }
    }
}