using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Api.Domain.Entities
{
    public class Pedido : BaseEntity
    {
        public decimal ValorTotal { get; set; }
        public int TempoDePreparo { get; set; }
        public long ItemPedidoId { get; set; }
        public virtual ItemPedido ItemPedido { get; set; }
        public virtual ICollection<Adicional> Adicionais { get; set; }

        public void CalculaTempoDePreparo()
        {
            TempoDePreparo = ItemPedido.Tamanho.TempoDePreparo
                 + ItemPedido.Sabor.TempoDePreparo
                     + (Adicionais != null ? Adicionais.Sum(s => s.TempoDePreparo) : 0);
        }

        public void CalculaValorTotal()
        {
            ValorTotal = ItemPedido.Tamanho.Valor
               + ItemPedido.Sabor.Valor
                   + (Adicionais != null ? Adicionais.Sum(s => s.Valor) : 0);
        }
    }
}