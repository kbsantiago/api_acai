using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.AdicionalService;
using Api.Domain.Interfaces.ItemPedidoAdicionalService;
using Api.Domain.Interfaces.ItemPedidoService;
using Api.Domain.Interfaces.PedidoService;
using Api.Domain.Interfaces.SaborService;
using Api.Domain.Interfaces.TamanhoService;
using Api.Service.Services;
using ApiService.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjector
{
    public class ConfigureDependencies
    {
        public static void ConfigureDependencyService(IServiceCollection serviceCollection) 
        {
            serviceCollection.AddScoped<IPedidoService, PedidoService>();
            serviceCollection.AddScoped<ISaborService, SaborService>();
            serviceCollection.AddScoped<ITamanhoService, TamanhoService>();
            serviceCollection.AddScoped<IAdicionalService, AdicionalService>();
            serviceCollection.AddScoped<IItemPedidoAdicionalService, ItemPedidoAdicionalService>();
            serviceCollection.AddScoped<IItemPedidoService, ItemPedidoService>();
        }

        public static void ConfigureDependencyRepository(IServiceCollection serviceColletion)
        {
            serviceColletion.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            serviceColletion.AddDbContext<Contexto>(
                options => options.UseSqlServer("Server=.\\;Database=DbAcai;User Id=sa;Password=novasenha")
            );
        }
    }
}