using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NetChallenge.Data;
using NetChallenge.Domain;

public class MockContext : DbContext//AppDbContext
{
    private static MockContext _singletonMockContextInstance;
    private List<Booking> _bookings = new();
    public static MockContext SingletonMockContextInstance
    {
        get
        {
            if (_singletonMockContextInstance is null) _singletonMockContextInstance = new();
            return _singletonMockContextInstance;
        }
    }
    public IQueryable<Booking> Bookings => _bookings.AsQueryable();
    public MockContext()
    {

        Bookings
            .ToList()
            .AddRange(
                new List<Booking>(){
                    new(){
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
                            Name="Larry Page",
                            Email="larry@gamil.com"
                        },
                        DateTime = new DateTime(1998,1,1,0,0,0),
                        Duration = TimeSpan.FromHours(5),
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
            });
    }
}


// public DbSet<Location> Locations => Set<Location>();
// public DbSet<Office> Offices =>Set<Office>();
// public DbSet<Facility> Facilities => Set<Facility>();
// public DbSet<Booking> Bookings => Set<Booking>();
// public DbSet<User> Users => Set<User>();

//}

// public class MockContextExceptionHandler : ISqlExceptionHandler
// {
//     public void OnException(SqliteException exception)
//     {
//         Console.WriteLine($" MockContext Exception: {exception.Message}");
//     }
// }