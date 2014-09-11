using System.Linq;
using QueryObjectMvc.Interfaces;

namespace QueryObjectMvc.Contexts
{
    public partial class QueryObjectContextDataContext : IStorage
    {
        IQueryable<Author> IStorage.Authors
        {
            get { return Authors; }
        }
    }
}