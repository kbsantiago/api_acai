namespace Api.Domain.Entities
{
    public class ItemPedidoAdicional : BaseEntity
    {
        public long ItemPedidoId { get; set; }
        public virtual ItemPedido ItemPedido { get; set; }
        public long AdicionalId { get; set; }
        public virtual Adicional Adicional { get; set; }
    }
}
