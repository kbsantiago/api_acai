using Api.Data.Context;
using Api.Domain.Entities;

namespace Api.Data.Context
{
    public class DbInitializer
    {
        public static void Seed(Contexto context)
        {
            //Inicializar tamanhos
            var pequeno = new Tamanho()
            {
                Descricao = "Açaí pequeno (300ml)",
                TempoDePreparo = 5,
                Valor = 10
            };
            context.Add(pequeno);

            var medio = new Tamanho()
            {
                Descricao = "Açaí médio (500ml)",
                TempoDePreparo = 7,
                Valor = 13
            };
            context.Add(medio);

            var grande = new Tamanho()
            {
                Descricao = "Açaí grande (750ml)",
                TempoDePreparo = 10,
                Valor = 15
            };
            context.Add(grande);

            //Inicializar sabores
            var morango = new Sabor()
            {
                Descricao = "Morango",
                TempoDePreparo = 0,
                Valor = 0 
            };
            context.Add(morango);

            var banana = new Sabor()
            {
                Descricao = "Banana",
                TempoDePreparo = 0,
                Valor = 0
            };
            context.Add(banana);

            var kiwi = new Sabor()
            {
                Descricao = "Kiwi",
                TempoDePreparo = 5,
                Valor = 0
            };
            context.Add(kiwi);

            //Inicilizar Adicionais
            var granola = new Adicional()
            {
                Descricao = "Granola",
                TempoDePreparo = 0,
                Valor = 0,
            };
            context.Add(granola);

            var leiteNinho = new Adicional()
            {
                Descricao = "Leite Ninho",
                TempoDePreparo = 0,
                Valor = 3,
            };
            context.Add(leiteNinho);

            var pacoca = new Adicional()
            {
                Descricao = "Leite Ninho",
                TempoDePreparo = 3,
                Valor = 3,
            };
            context.Add(pacoca);

            context.SaveChanges();
        }
    }
}
