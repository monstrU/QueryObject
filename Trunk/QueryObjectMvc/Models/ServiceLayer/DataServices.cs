using QueryObjectMvc.Contexts;
using QueryObjectMvc.Models;
using QueryObjectMvc.Models.QueryObjects;
using QueryObjectMvc.Models.ServiceLayer;

namespace MvcExample.Models.ServiceLayer
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Linq.Expressions;


    public class DataServices : IDataServices
    {
        
        public AuthorModel GetAuthor(string nickName)
        {
            string connect = ConfigurationManager.ConnectionStrings["QueryObjectConnectionString"].ConnectionString;
            var authorQuery = new AuthorByNickNameQuery(new QueryObjectContextDataContext(connect), nickName);
            var author = authorQuery.Execute();
            AuthorModel result=null;
            if (author!=null)
            {
                result = new AuthorModel()
                {
                    AuthorId = author.Id,
                    Name = author.Name,
                    NickName = author.NickName
                };
            }

            return result;
        }
    }
}