using PersonRegister.Core.Application.Interfaces.Repositories;
using System.Collections.Generic;

namespace PersonRegister.Infrastructure.Database.Implementations
{
    internal abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly PersonRegister_DbContext context;
        public Repository(PersonRegister_DbContext context) => this.context = context;


        public virtual void Create(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            var entity = context.Set<TEntity>().Find(id);
            if (entity != null)
            {
                context.Set<TEntity>().Remove(entity);
                context.SaveChanges();
            }
        }

        public virtual void Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            context.SaveChanges();
        }

        public virtual IEnumerable<TEntity> GetAll() => context.Set<TEntity>();

        public virtual TEntity GetById(int id) => context.Set<TEntity>().Find(id);
        public bool Exists(int id) => context.Set<TEntity>().Find(id) != null;

    }
}
