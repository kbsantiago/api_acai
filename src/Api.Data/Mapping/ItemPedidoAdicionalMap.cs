using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Api.Data.Mapping
{
    public class ItemPedidoAdicionalMap : IEntityTypeConfiguration<ItemPedidoAdicional>
    {
        public void Configure(EntityTypeBuilder<ItemPedidoAdicional> builder)
        {
            builder.ToTable("ItemPedidoAdicionais");

            builder.HasKey(p => p.Id);
        }
    }
}
