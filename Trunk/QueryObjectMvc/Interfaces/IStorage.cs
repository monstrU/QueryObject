using System;
using System.Linq;
using QueryObjectMvc.Contexts;

namespace QueryObjectMvc.Interfaces
{
    public interface IStorage : IDisposable
    {
        IQueryable<Author> Authors { get; }
    }
}
