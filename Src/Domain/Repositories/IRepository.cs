using System.Linq.Expressions;
using Domain.Common;

namespace Domain.Repositories;

public interface IRepository<TEntity> where TEntity : Entity
{
    Task<IEnumerable<TEntity>> GetAll();

    Task<TEntity> GetById(Guid id);

    Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);

    Task Insert(TEntity entity);

    Task<TEntity> Update(TEntity entity);

    Task Delete(Guid id);
}
