using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NetChallenge.Domain;

public class MockContext : DbContext
{
    private List<Booking> _bookings;
    public MockContext()
    {
        _bookings = new List<Booking>
            {
            new (){
                User= new(){
                        Name="John Doe",
                        Email="john001@gmail.com"
                    },
                DateTime = new DateTime(2023,12,24,0,0,0),
                Duration = TimeSpan.FromHours(2),
                Office = new(){
                    Name="Soho",
                    Location= new(){
                        Name="New York",
                    }
                }
            },
            new(){
                User= new(){
                    Name="Monica Smith",
                    Email="monica123@gmail.com"
                },
                DateTime = new DateTime(2023,12,25,0,0,0),
                Duration = TimeSpan.FromHours(2),
                Office = new(){
                    Name="Soho",
                    Location= new(){
                        Name="New York",
                    }
                },
            }
        }; 
            
    }

    public IQueryable<Booking> Bookings => _bookings.AsQueryable();

    // Implement other methods...
}