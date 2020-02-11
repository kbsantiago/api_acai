using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.AdicionalService;

namespace Api.Service.Services
{
    public class AdicionalService : IAdicionalService
    {
         private IRepository<Adicional> _repository;

        public AdicionalService(IRepository<Adicional> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(long id)
        {
             return await _repository.DeleteAsync(id);
        }

        public async Task<Adicional> Get(long id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<Adicional>> GetAll()
        {
            return await _repository.SelectAllAsync();
        }

        public async Task<Adicional> Post(Adicional adicional)
        {
            return await _repository.SaveAsync(adicional);
        }

        public async Task<Adicional> Put(Adicional adicional)
        {
            return await _repository.UpdateAsync(adicional);
        }
    }
}