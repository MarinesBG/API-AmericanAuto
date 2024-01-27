using AmericanAuto.Common.Models.Base;

namespace AmericanAuto.Services.Interfaces
{
    public interface IBaseCRUD<TEntity>
    {
        public Task<EntityResult<List<TEntity>>> GetAll();

        public Task<EntityResult<TEntity>> GetById(int id);

        public Task<EntityResult<TEntity>> Create(TEntity customer);

        public Task<EntityResult<TEntity>> Update(int id, TEntity customer);

        public Task<EntityResult<TEntity>> Delete(int id);
    }
}
