using Microsoft.EntityFrameworkCore;
using Api.Domain.Entities;
using Api.Data.Mapping;

namespace Api.Data.Context
{
    public class Contexto : DbContext
    {
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Tamanho> Tamanhos { get; set; }
        public DbSet<Sabor> Sabores { get; set; }
        public DbSet<Adicional> Adicionais { get; set; }
        public DbSet<ItemPedidoAdicional> ItemPedido { get; set; }
        public DbSet<ItemPedidoAdicional> ItemPedidoAdicional { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options) {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Pedido>(new PedidoMap().Configure);
            modelBuilder.Entity<Tamanho>(new TamanhoMap().Configure);
            modelBuilder.Entity<Sabor>(new SaborMap().Configure);
            modelBuilder.Entity<Adicional>(new AdicionalMap().Configure);
            modelBuilder.Entity<ItemPedido>(new ItemPedidoMap().Configure);
            modelBuilder.Entity<ItemPedidoAdicional>(new ItemPedidoAdicionalMap().Configure);
        }
    }
}