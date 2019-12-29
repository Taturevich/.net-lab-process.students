using System.Data.Entity;
using System.Linq;
using EF_Task.Scope;

namespace EF_Task.Repository
{
    public interface IEntityStorage<out T>
    {
        IQueryable<T> GetAll();
    }

    internal class NorthwindEntityStorage<TEntity> : IEntityStorage<TEntity>
        where TEntity : class
    {
        private readonly IContextLocator<NorthwindContext> _contextLocator;

        public NorthwindEntityStorage(IContextLocator<NorthwindContext> contextLocator)
        {
            _contextLocator = contextLocator;
        }

        public IQueryable<TEntity> GetAll()
        {
            var context = _contextLocator.GetCurrentDbContext();
            return context.Set<TEntity>().AsNoTracking();
        }
    }
}
