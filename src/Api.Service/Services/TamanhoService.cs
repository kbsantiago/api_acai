using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.TamanhoService;

namespace Api.Service.Services
{
    public class TamanhoService : ITamanhoService
    {
        private IRepository<Tamanho> _repository;

        public TamanhoService(IRepository<Tamanho> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(long id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<Tamanho> Get(long id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<Tamanho>> GetAll()
        {
            return await _repository.SelectAllAsync();
        }

        public async Task<Tamanho> Post(Tamanho tamanho)
        {
            return await _repository.SaveAsync(tamanho);
        }

        public async Task<Tamanho> Put(Tamanho tamanho)
        {
            return await _repository.UpdateAsync(tamanho);
        }
    }
}