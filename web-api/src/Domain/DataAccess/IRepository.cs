namespace BogdaroneApp.Domain.DataAccess;

public interface IRepository<T> where T: class
{
    IEnumerable<T> GetAll();
    T GetById(string id);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}