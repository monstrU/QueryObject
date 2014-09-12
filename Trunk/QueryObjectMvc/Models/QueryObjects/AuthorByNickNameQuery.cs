using System.Linq;
using QueryObjectMvc.Contexts;
using QueryObjectMvc.Interfaces;

namespace QueryObjectMvc.Models.QueryObjects
{
    public class AuthorByNickNameQuery : IQueryObjects<Author>
    {
        private readonly IStorage _provider;
        private readonly string _nick;

        public AuthorByNickNameQuery(IStorage provider,  string nick)
        {
            _provider = provider;
            _nick = nick;
        }

        public virtual Author Execute()
        {
            // Query object does not responsible for _provider lifecycle
            // so I removed an using statement.
            return _provider.Authors.SingleOrDefault(a => a.NickName.StartsWith(_nick));
        }
    }
}