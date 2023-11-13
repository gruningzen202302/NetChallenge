using System;
using System.Collections.Generic;
using NetChallenge.Abstractions;
using NetChallenge.Data;
using NetChallenge.Domain;
using SQLitePCL;

namespace NetChallenge.Infrastructure;

public class BookingRepository : IBookingRepository
{
    private List<Booking> context_Bookings = new(){
        new(){

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

    public IEnumerable<Booking> GetAll()=> new List<Booking>();
}
