using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.ItemPedidoAdicionalService;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Services
{
    public class ItemPedidoAdicionalService : IItemPedidoAdicionalService
    {
        private IRepository<ItemPedidoAdicional> _repository;

        public ItemPedidoAdicionalService(IRepository<ItemPedidoAdicional> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(long id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ItemPedidoAdicional>> GetAll()
        {
            return await _repository.SelectAllAsync();
        }

        public async Task<ItemPedidoAdicional> Get(long id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<ItemPedidoAdicional> Post(ItemPedidoAdicional itemPedido)
        {
            return await _repository.SaveAsync(itemPedido);
        }

        public async Task<ItemPedidoAdicional> Put(ItemPedidoAdicional itemPedido)
        {
            return await _repository.UpdateAsync(itemPedido);
        }

        public IEnumerable<ItemPedidoAdicional> GetByItemPedido(long id)
        {
            return _repository.SelectAllAsync().Result.Where(p => p.ItemPedidoId == id);
        }
    }
}
