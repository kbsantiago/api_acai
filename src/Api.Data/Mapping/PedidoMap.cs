using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedidos");

            builder.HasKey(p => new { p.Id });

            builder.Property(p => p.Id)
                   .UseHiLo();

            builder.Property(p => p.ValorTotal)
                   .IsRequired()
                   .HasDefaultValue(0);

            builder.Property(p => p.TempoDePreparo)
                   .IsRequired()
                   .HasDefaultValue(0);
        }
    }
}