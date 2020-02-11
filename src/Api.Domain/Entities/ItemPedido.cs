using System.Collections.Generic;

namespace Api.Domain.Entities
{
    public class ItemPedido: BaseEntity
    {
        public virtual Pedido Pedido { get; set; }
        public long SaborId { get; set; }
        public virtual Sabor Sabor { get; set; }
        public long TamanhoId { get; set; }
        public virtual Tamanho Tamanho { get; set; }
    }
}