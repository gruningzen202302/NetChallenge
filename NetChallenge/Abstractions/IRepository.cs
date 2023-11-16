using System;
using System.Collections.Generic;

namespace NetChallenge.Abstractions
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Func<T, bool> predicate);
        T GetOne(Func<T, bool> predicate);
        void Add(T item);
        IEnumerable<T> GetAllDeprecated();
    }
}