using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NetChallenge.Data;
using NetChallenge.Data.Utils;
using NetChallenge.Domain;

public class MockContext : DbContext, IDbContext
{
    private static MockContext _singletonMockContextInstance;
    public static MockContext SingletonMockContextInstance
    {
        get
        {
            if (_singletonMockContextInstance is null) _singletonMockContextInstance = new();
            return _singletonMockContextInstance;
        }
    }
    public IQueryable<Booking> Bookings { get; set; }
    public IQueryable<Facility> Facilities { get; set; }
    public IQueryable<Location> Locations { get; set; }
    public IQueryable<Office> Offices { get; set; }
    public IQueryable<User> Users { get; set; }

    public MockContext()
    {

        Office defaultOffice = new Office
        {
            Location = AddLocationDomainMother.Default,
            Name = "Default Office",
            MaxCapacity = 10,
            Facilities = new List<Facility> { new() { Title = "Internet", } },
        };
        var offices = new List<Office> { };
        Offices = offices.AsQueryable();


        var bookings = new List<Booking>();
        bookings
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
                                Neighborhood = "NY",
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
                                Neighborhood="NY"
                            }
                        },
                    }
            });

        Bookings = bookings.AsQueryable();


        var locations = new List<Location>();
        Locations = locations.AsQueryable();

        Users = new List<User>{
            new(){
                Name="test_user",
                Email="test@gmail.com"
            },
            new(){
                Name="John Doe",
                Email="john001@gmail.com"
            },
            new(){
                Name="Larry Page",
                Email="larry@gamil.com"
            },
            new(){
                Name="Monica Smith",
                Email="monica123@gmail.com"
            },
        }.AsQueryable();

    }
}

