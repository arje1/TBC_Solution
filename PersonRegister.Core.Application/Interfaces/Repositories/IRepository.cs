using System.Collections.Generic;

namespace PersonRegister.Core.Application.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        abstract IEnumerable<TEntity> GetAll();
        abstract TEntity GetById(int id);
        abstract void Create(TEntity entity);
        abstract void Update(TEntity entity);
        abstract void Delete(int id);
        abstract bool Exists(int id);
    }
}
