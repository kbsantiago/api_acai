using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.PedidoService
{
    public interface IPedidoService
    {
        Task<Pedido> Get(long id);
        Task<IEnumerable<Pedido>> GetAll();
        Task<Pedido> Post(Pedido item);
        Task<Pedido> Put(Pedido item);
        Task<bool> Delete(long id);
        Pedido GetByItemPedido(long id);
    }
}