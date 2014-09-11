namespace QueryObjectMvc.Models.QueryObjects
{
    public interface IQueryObjects<out T> where T: class
    {
        T Execute();
    }
}