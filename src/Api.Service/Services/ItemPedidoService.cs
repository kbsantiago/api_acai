
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.ItemPedidoService;

namespace Api.Service.Services
{
    public class ItemPedidoService : IItemPedidoService
    {
        private IRepository<ItemPedido> _repository;

        public ItemPedidoService(IRepository<ItemPedido> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(long id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<ItemPedido> Get(long id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<ItemPedido>> GetAll()
        {
            return await _repository.SelectAllAsync();
        }

        public async Task<ItemPedido> Post(ItemPedido itemPedido)
        {
            return await _repository.SaveAsync(itemPedido);
        }

        public async Task<ItemPedido> Put(ItemPedido itemPedido)
        {
            return await _repository.UpdateAsync(itemPedido);
        }
    }
}
