using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<Contexto>
    {
        public Contexto CreateDbContext(string[] args)
        {
            var connectionString = "Server=.\\;Database=DbAcai;User Id=sa;Password=novasenha";
            var optionsBuilder = new DbContextOptionsBuilder<Contexto>();
            optionsBuilder.UseSqlServer(connectionString);
            return new Contexto(optionsBuilder.Options);             
        }
    }
}