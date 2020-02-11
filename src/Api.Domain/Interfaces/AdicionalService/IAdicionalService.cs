using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.AdicionalService
{
    public interface IAdicionalService
    {
         Task<Adicional> Get(long id);
         Task<IEnumerable<Adicional>> GetAll();
         Task<Adicional> Post(Adicional adicional);
         Task<Adicional> Put(Adicional adicional);
         Task<bool> Delete(long id);
    }
}