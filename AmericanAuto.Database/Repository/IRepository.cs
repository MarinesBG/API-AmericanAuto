using AmericanAuto.Database.Entities.Base;
using System.Linq.Expressions;

namespace AmericanAuto.Database.Core
{
    public interface IRepository<TEntity>
        where TEntity : BaseEntity
    {
        public Task<List<TEntity>> GetAll();

        public Task<TEntity> GetById(int id);

        public Task<TEntity> Create(TEntity entity);

        public Task<TEntity> Update(int id, TEntity entity);

        public Task<TEntity> Delete(int id);
    }
}
