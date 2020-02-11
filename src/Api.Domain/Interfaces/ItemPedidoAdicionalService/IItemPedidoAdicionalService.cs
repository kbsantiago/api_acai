using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.ItemPedidoAdicionalService
{
    public interface IItemPedidoAdicionalService
    {
        Task<ItemPedidoAdicional> Get(long id);
        Task<IEnumerable<ItemPedidoAdicional>> GetAll();
        Task<ItemPedidoAdicional> Post(ItemPedidoAdicional itemPedidoAdicional);
        Task<ItemPedidoAdicional> Put(ItemPedidoAdicional itemPedidoAdicional);
        Task<bool> Delete(long id);
        IEnumerable<ItemPedidoAdicional> GetByItemPedido(long id);
    }
}