using System.Linq;
using PJYAAC_SG1_21_22_2.Repository.DbContexts;
using PJYAAC_SG1_21_22_2.Repository.Interfaces;

namespace PJYAAC_SG1_21_22_2.Repository.Repositories
{
    public abstract class RepositoryBase<TEntity, TKey> : IRepositoryBase<TEntity, TKey> where TEntity : class
    {
        protected BicycleAppDbContext Context;

        protected RepositoryBase(BicycleAppDbContext context)
        {
            Context = context;
        }

        public IQueryable<TEntity> ReadAll()
        {
            return Context.Set<TEntity>();
        }

        public abstract TEntity Read(TKey id);

        public TEntity Create(TEntity entity)
        {
            var result = Context.Add(entity);
            Context.SaveChanges();
            return result.Entity;
        }

        public TEntity Update(TEntity entity)
        {
            var result = Context.Update(entity);
            Context.SaveChanges();
            return result.Entity;
        }

        public void Delete(TKey id)
        {
            Context.Remove(Read(id));
            Context.SaveChanges();
        }
    }
}