using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using NetChallenge.Abstractions;
using NetChallenge.Data;
using NetChallenge.Domain;
using NetChallenge.Migrations;
using SQLitePCL;

namespace NetChallenge.Infrastructure;

public class BookingRepository : IBookingRepository
{
    //private readonly DbContext _context;
    private readonly IDbContext _context;
    public BookingRepository()
    {
        _context = new MockContext();
    }
    public BookingRepository(IDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Booking> GetAll()
    {
        //var bookings = _context.Set<Booking>().AsEnumerable();
        var bookings = _context.Bookings.AsEnumerable();
        var ls = bookings.ToList();
        return bookings;
    }

    public void Add(Booking booking)
    {
        bool userValidationSuccedded = this.ValidateUser(booking);
        if(!userValidationSuccedded) throw new Exception("There was a problem with the user");
        _context.Bookings.ToList().Add(booking); 
        
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

    public IEnumerable<Booking> GetAllDeprecated() => throw new NotImplementedException();

    public Booking GetOne(Func<Booking, bool> predicate)
    {
        return _context.Bookings.Single(predicate) ;
    }

    public IEnumerable<Booking> GetSome(Func<Booking, bool> predicate)
    {
        IEnumerable<Booking> bookings = Enumerable.Empty<Booking>();
        bookings = _context.Bookings.Where(predicate);
        return bookings;
    }
    private void DismissMockContextSqlException()
    {
        if (_context.GetType() == typeof(MockContext))
        {
            try
            {
                _context.Bookings.ToList();
            }
            catch (SqliteException)
            {
                Console.WriteLine($"{nameof(SqliteException)} dismissed in {nameof(MockContext)}");
            }
        }

    }
}
