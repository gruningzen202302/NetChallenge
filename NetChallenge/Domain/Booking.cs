using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetChallenge.Domain
{
    public class Booking : EntityBase
    {
        public int OfficeId { get; set; }
        public int LocationId {get; set; }
        public virtual Office Office { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        [Required] public DateTime DateTime { get; set; }
        public TimeSpan Duration { get; set; }
    }
}