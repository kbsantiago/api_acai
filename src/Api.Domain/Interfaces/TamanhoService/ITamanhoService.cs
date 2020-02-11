using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.TamanhoService
{
    public interface ITamanhoService
    {
         Task<Tamanho> Get(long id);
         Task<IEnumerable<Tamanho>> GetAll();
         Task<Tamanho> Post(Tamanho tamanho);
         Task<Tamanho> Put(Tamanho tamanho);
         Task<bool> Delete(long id);
    }
}