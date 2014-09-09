namespace QueryObjectMvc.Models.ServiceLayer
{
    public interface IDataServices
    {
        
        AuthorModel GetAuthor(string nickName);
    }
}
