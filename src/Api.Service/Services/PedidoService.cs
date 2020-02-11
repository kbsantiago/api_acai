using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.PedidoService;

namespace Api.Service.Services
{
    public class PedidoService : IPedidoService 
    {
        private IRepository<Pedido> _repository;

        public PedidoService(IRepository<Pedido> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(long id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Pedido>> GetAll()
        {
            return await _repository.SelectAllAsync();
        }

        public async Task<Pedido> Get(long id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<Pedido> Post(Pedido pedido)
        {
            //pedido.TempoDePreparo = pedido.CalculaTempoDePreparo();
            //pedido.ValorTotal = pedido.CalculaValorTotal();
            var result = await _repository.SaveAsync(pedido);
            return result;
        }

        public async Task<Pedido> Put(Pedido pedido)
        {
            return await _repository.UpdateAsync(pedido);
        }

        public Pedido GetByItemPedido(long id) 
        {
            return _repository.SelectAllAsync().Result
                              .Where(p => p.ItemPedidoId == id)
                              .FirstOrDefault();
        }
    }
}