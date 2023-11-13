using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetChallenge.Domain
{
    public class Booking
    {
        public virtual Location Location { get; }
        [Required, ForeignKey(nameof(LocationId))] public int LocationId { get; set; }

        public virtual Office Office { get; set; }
        [Required, ForeignKey("OfficeId")] public int OfficeId { get; set; }

        public virtual Location User { get; set; }
        [Required, ForeignKey("UserId")] public int UserId { get; set; }
    }
}