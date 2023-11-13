using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetChallenge.Domain
{
    public class Booking
    {
        public virtual Office Office { get; set; }
        //[Required, ForeignKey("OfficeId")] 
        public int OfficeId { get; set; }
        public virtual User User { get; set; }
        //[Required, ForeignKey("UserId")] 
        public int UserId { get; set; }
        [Required] public DateTime DateTime { get; set; }
        public TimeSpan Duration { get; set; }
    }
}