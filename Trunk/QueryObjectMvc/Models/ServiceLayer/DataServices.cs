using System.Configuration;
using QueryObjectMvc.Contexts;
using QueryObjectMvc.Models;
using QueryObjectMvc.Models.QueryObjects;
using QueryObjectMvc.Models.ServiceLayer;

namespace MvcExample.Models.ServiceLayer
{
    public class DataServices : IDataServices
    {
        public AuthorModel GetAuthor(string nickName)
        {
            var connect = ConfigurationManager.ConnectionStrings["QueryObjectConnectionString"].ConnectionString;
            using (var context = new QueryObjectContextDataContext(connect))
            {
                var authorQuery = new AuthorByNickNameQuery(context, nickName);

                var author = authorQuery.Execute();
                AuthorModel result = null;
                if (author != null)
                {
                    result = new AuthorModel
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
}