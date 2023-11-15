using System;
using System.ComponentModel.DataAnnotations;

public class PositiveTimeSpanAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value is TimeSpan timeSpan)
        {
            return timeSpan > TimeSpan.Zero;
        }
        return false;
    }
}