using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
         Task<T> SaveAsync(T t);
         Task<T> UpdateAsync(T t);
         Task<bool> DeleteAsync(long id);
         Task<T> SelectAsync(long id);
         Task<IEnumerable<T>> SelectAllAsync();
    }
}