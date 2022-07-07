using System.Linq.Expressions;
using Chat.Application.Common.Interfaces.Repository;

namespace Chat.Persistence.Repository;

public class Repository<T> : IRepository<T> where T : class  
{
    public async Task<T> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<T> GetAll()
    {
        throw new NotImplementedException();
    }

    public IQueryable<T> Where(Expression<Func<T, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        throw new NotImplementedException();
    }

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }

    public void Remove(T entity)
    {
        throw new NotImplementedException();
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        throw new NotImplementedException();
    }
}