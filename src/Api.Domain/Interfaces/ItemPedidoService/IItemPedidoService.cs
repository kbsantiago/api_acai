using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.ItemPedidoService
{
    public interface IItemPedidoService
    {
         Task<ItemPedido> Get(long id);
         Task<IEnumerable<ItemPedido>> GetAll();
         Task<ItemPedido> Post(ItemPedido itemPedido);
         Task<ItemPedido> Put(ItemPedido itemPedido);
         Task<bool> Delete(long id);
    }
}