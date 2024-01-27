using AmericanAuto.Database.Core;
using AmericanAuto.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace AmericanAuto.Database.Repository
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly AppDbContext _dbContext;
        private DbSet<Customer> _table;

        public CustomerRepository(AppDbContext context)
        {
            _dbContext = context;
            _table = _dbContext.Set<Customer>();
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _table
              .Include(x => x.Vehicles)
              .ThenInclude(y => y.Parts)
              .ToListAsync();
        }

        public async Task<Customer> GetById(int id)
        {
            return await _table
              .Include(x => x.Vehicles)
              .ThenInclude(y => y.Parts)
              .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Customer> Create(Customer entity)
        {
            await _table.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Customer> Update(int id, Customer entity)
        {
            var oldEntity = await _table
              .Include(x => x.Vehicles)
              .ThenInclude(y => y.Parts)
              .FirstOrDefaultAsync(x => x.Id == id);
           
            if (oldEntity == null)
            {

            }

            //Mapping old and new entity

            _table.Update(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Customer> Delete(int id)
        {
            var entity = await _table
              .Include(x => x.Vehicles)
              .ThenInclude(y => y.Parts)
              .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                // throw new Exception();
            }

            _table.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
