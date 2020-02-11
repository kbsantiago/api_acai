using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class TamanhoMap : IEntityTypeConfiguration<Tamanho>
    {
        public void Configure(EntityTypeBuilder<Tamanho> builder)
        {
            builder.ToTable("Tamanhos");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .UseHiLo();

            builder.HasIndex(p => p.Descricao)
                   .IsUnique();

            builder.Property(p => p.Descricao)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(p => p.TempoDePreparo)
                   .IsRequired();
        }
    }
}