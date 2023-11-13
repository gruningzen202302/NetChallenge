using System;
using System.Collections.Generic;
using System.Linq;
using NetChallenge.Abstractions;
using NetChallenge.Data;
using NetChallenge.Domain;
using SQLitePCL;

namespace NetChallenge.Infrastructure;

public class BookingRepository : IBookingRepository
{
    private List<Booking> context_Bookings = new(){
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
            },
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
    private readonly AppDbContext _context;
    public BookingRepository(){}
    public BookingRepository(AppDbContext context)
    {
        _context = context; 
    }

    public IEnumerable<Booking> AsEnumerable()
    {
        throw new System.NotImplementedException();
    }

    public void Add(Booking booking)
    {
        if(_context is null){ context_Bookings.Add(booking);}

        bool userValidationSuccedded = this.ValidateUser(booking);
        if(!userValidationSuccedded) throw new Exception("There was a problem with the user");
        _context.Bookings.Add(booking); 
        
    }

    private bool ValidateUser(Booking booking)
    {
        throw new NotImplementedException();
    }
    private bool ValidateOffice(Office office){
        if(office is null) return false;
        //bool 
        //if()
        return true;
    }

    public IEnumerable<Booking> GetAll()=> new List<Booking>();

    public Booking GetOne(Func<Booking, bool> predicate)
    {
        if(_context is null) return context_Bookings.Single(predicate);
            return _context.Bookings.Single(predicate) ;
    }
}
