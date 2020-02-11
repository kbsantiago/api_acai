using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.SaborService;

namespace Api.Service.Services
{
    public class SaborService : ISaborService
    {
        private IRepository<Sabor> _repository;

        public SaborService(IRepository<Sabor> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(long id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<Sabor> Get(long id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<Sabor>> GetAll()
        {
            return await _repository.SelectAllAsync();
        }

        public async Task<Sabor> Post(Sabor sabor)
        {
            return await _repository.SaveAsync(sabor);
        }

        public async Task<Sabor> Put(Sabor sabor)
        {
            return await _repository.UpdateAsync(sabor);
        }
    }
}