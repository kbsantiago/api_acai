using System.Reflection;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class ItemPedidoMap : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.ToTable("ItemPedido");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .UseHiLo();

            //builder.HasOne(p => p.Pedido)
            //      .WithOne(p => p.ItemPedido)
            //      .HasForeignKey<Pedido>(p => p.ItemPedidoId);
        }
    }
}
