using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class AdicionalMap : IEntityTypeConfiguration<Adicional>
    {
        public void Configure(EntityTypeBuilder<Adicional> builder)
        {
            builder.ToTable("Adicionais");

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