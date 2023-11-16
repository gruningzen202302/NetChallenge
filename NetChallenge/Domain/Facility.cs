using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetChallenge.Domain;

public class Facility : EntityBase
{
    public required string Title { get; set; }
    public string Description { get; set; }
    public Uri ImageUrl { get; set; }
    public int OfficeId { get; set; }
    public int LocationId { get; set; }

    [ForeignKey("OfficeId, LocationId")]
    public virtual Office Office { get; set; }
}