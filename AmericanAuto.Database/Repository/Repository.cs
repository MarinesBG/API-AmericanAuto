using AmericanAuto.Database.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AmericanAuto.Database.Core
{
    //public class Repository<TEntity> : IRepository<TEntity>
    //    where TEntity : BaseEntity
    //{
    //    private readonly AppDbContext _dbContext;
    //    private DbSet<TEntity> _table;

    //    public Repository(AppDbContext context)
    //    {
    //        _dbContext = context;
    //        _table = _dbContext.Set<TEntity>();
    //    }

    //    public async Task<List<TEntity>> GetAll(params Expression<Func<TEntity, object>>[] includes)
    //    {
    //        var query = _table.AsQueryable();
    //        query = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

    //        return await query.ToListAsync();
    //    }

    //    public async Task<TEntity> GetById(int id, params Expression<Func<TEntity, object>>[] includes)
    //    {
    //        var query = _table.AsQueryable();
    //        query = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

    //        return query.FirstOrDefault(entity => entity.Id == id);
    //    }

    //    public async Task<TEntity> Create(TEntity entity)
    //    {
    //        await _table.AddAsync(entity);
    //        await _dbContext.SaveChangesAsync();

    //        return entity;
    //    }

    //    public async Task<TEntity> Update(int id, TEntity entity)
    //    {
    //        _table.Attach(entity);
    //        _dbContext.Entry(entity).State = EntityState.Modified;
    //        await _dbContext.SaveChangesAsync();

    //        return entity;
    //    }

    //    public async Task<TEntity> Delete(int id)
    //    {
    //        var entity = await _table.FindAsync(id);

    //        _table.Remove(entity);
    //        await _dbContext.SaveChangesAsync();

    //        return entity;
    //    }
    //}
}
