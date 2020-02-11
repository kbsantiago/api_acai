using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.SaborService
{
    public interface ISaborService
    {
        Task<Sabor> Get(long id);
         Task<IEnumerable<Sabor>> GetAll();
         Task<Sabor> Post(Sabor sabor);
         Task<Sabor> Put(Sabor sabor);
         Task<bool> Delete(long id);
    }
}