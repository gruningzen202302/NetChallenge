using System;
using System.Collections.Generic;
using System.Linq;
using NetChallenge.Abstractions;
using NetChallenge.Data;
using NetChallenge.Domain;

namespace NetChallenge.Infrastructure;
public class UserRepository : IUserRepository
{
    private readonly IDbContext _context;
    public UserRepository()
    {
        _context = new MockContext();
    }
    public UserRepository(IDbContext dbContext)
    {
        _context = dbContext;
    }
    public void Add(User item)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<User> GetAll()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<User> GetAllDeprecated()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<User> GetMany(Func<User, bool> predicate)
    {
        throw new NotImplementedException();
    }
    public User GetOne(Func<User, bool> predicate) => _context.Users.Single(predicate);
}
