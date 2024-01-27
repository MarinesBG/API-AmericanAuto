using AmericanAuto.Common.Models.Base;
using AmericanAuto.Database.Core;
using AmericanAuto.Database.Entities;
using AmericanAuto.Services.Interfaces;

namespace AmericanAuto.Services.Services
{
    public class CustomerService : ICustomerService<Customer>
    {
        private readonly IRepository<Customer> _repository;

        public CustomerService(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task<EntityResult<List<Customer>>> GetAll()
        {
            try
            {
                var entity = await _repository.GetAll();

                return new EntityResult<List<Customer>>(entity);
            }
            catch (Exception ex)
            {
                return new EntityResult<List<Customer>>(ex.Message);
            }
        }

        public async Task<EntityResult<Customer>> GetById(int id)
        {
            try
            {
                var entity = await _repository.GetById(id);
                if(entity == null)
                {
                    return new EntityResult<Customer>($"Not Found");
                }

                return new EntityResult<Customer>(entity);
            }
            catch (Exception ex)
            {
                return new EntityResult<Customer>(ex.Message);
            }
        }

        public async Task<EntityResult<Customer>> Create(Customer customer)
        {
            try
            {
                var entity = await _repository.Create(customer);

                return new EntityResult<Customer>(entity);
            }
            catch (Exception ex)
            {
                return new EntityResult<Customer>(ex.Message);
            }
        }

        public async Task<EntityResult<Customer>> Update(int id, Customer customer)
        {
            try
            {
                var entity = await _repository.Update(id, customer);

                return new EntityResult<Customer>(entity);
            }
            catch (Exception ex)
            {
                return new EntityResult<Customer>(ex.Message);
            }
        }

        public async Task<EntityResult<Customer>> Delete(int id)
        {
            try
            {
                var entity = await _repository.Delete(id);

                return new EntityResult<Customer>(entity);
            }
            catch (Exception ex)
            {
                return new EntityResult<Customer>(ex.Message);
            }
        }
    }
}
