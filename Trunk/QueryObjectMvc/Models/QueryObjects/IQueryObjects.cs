using QueryObjectMvc.Interfaces;

namespace QueryObjectMvc.Models.QueryObjects
{
    public interface IQueryObjects<T> where T: class
    {
        IStorage Provider { get; set; }
        
        T Execute();
    }
}