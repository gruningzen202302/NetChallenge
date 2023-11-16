using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NetChallenge.Data;
using NetChallenge.Domain;

public class MockContext : DbContext, IDbContext
{
    private static MockContext _singletonMockContextInstance;
    private List<Booking> _bookings = new();
    private List<Facility> _facilities = new();
    private List<Location> _locations = new();
    private List<Office> _offices = new();
    private List<User> _users = new();
    public static MockContext SingletonMockContextInstance
    {
        get
        {
            if (_singletonMockContextInstance is null) _singletonMockContextInstance = new();
            return _singletonMockContextInstance;
        }
    }
    public IQueryable<Booking> Bookings => _bookings.AsQueryable();
    public IQueryable<Facility> Facilities => _facilities.AsQueryable();
    public IQueryable<Location> Locations => _locations.AsQueryable();
    public IQueryable<Office> Offices => _offices.AsQueryable();
    public IQueryable<User> Users => _users.AsQueryable();

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

