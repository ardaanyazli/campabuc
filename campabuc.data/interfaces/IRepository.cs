using System.Linq.Expressions;

namespace campabuc.data.interfaces;

public interface IRepository<T>
{
    public Task<IEnumerable<T>> GetAll();
    public Task<T> Find(object id);
    public Task<IEnumerable<T>> Filter(Expression<Func<T, bool>> predicate);
}

