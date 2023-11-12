using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetChallenge.Domain
{
    public class Office:EntityBase
    {
        public string Name { get; set; }
        public int MaxCapacity { get; set; }

        [Required, ForeignKey("LocationId")]
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<Facility> Facilities { get; set; }
    }
}