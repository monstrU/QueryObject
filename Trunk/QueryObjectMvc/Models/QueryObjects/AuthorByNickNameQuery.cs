using System.Linq;
using Microsoft.Ajax.Utilities;
using QueryObjectMvc.Contexts;
using QueryObjectMvc.Interfaces;

namespace QueryObjectMvc.Models.QueryObjects
{
    public class AuthorByNickNameQuery : IQueryObjects<Author>
    {
        public IStorage Provider { get; set; }

        

        public string Nick { get; set; }

        public AuthorByNickNameQuery(IStorage provider,  string nick)
        {
            Provider = provider;
            Nick = nick;
            
        }

        public virtual Author Execute()
        {
            Author result = null;
            
            //using (var context=Provider )
            using (var context = Provider as QueryObjectContextDataContext)
            {
                if (context != null)
                {
                    result = context.Authors.SingleOrDefault(a => a.NickName.StartsWith(Nick));
                    
                }
            }
            return result;
        }
    }
}