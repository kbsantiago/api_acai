using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly Contexto _contexto;
        private DbSet<T> _dataSet;

        public BaseRepository(Contexto contexto)
        {
            _contexto = contexto;
            _dataSet = _contexto.Set<T>();
        }

        public async Task<IEnumerable<T>> SelectAllAsync()
        {
            try 
            {
                return await _dataSet.ToListAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> SelectAsync(long id)
        {
            try 
            {
                return await _dataSet.SingleOrDefaultAsync(p => p.Id == id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> SaveAsync(T t)
        {
            try 
            {
                t.CreatedDate = DateTime.UtcNow;
                _dataSet.Add(t);
                await _contexto.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return t;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            try 
            {
                var result = await _dataSet.SingleOrDefaultAsync(p => p.Id == id);
                if(result == null) { return false; }

                _dataSet.Remove(result);
                await _contexto.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> UpdateAsync(T t)
        {
            try 
            {
                var result = await _dataSet.SingleOrDefaultAsync(p => p.Id == t.Id);
                if(result == null) { return null; }

                t.CreatedDate = result.CreatedDate;

                _contexto.Entry(result).CurrentValues.SetValues(t);
                await _contexto.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return t;
        }
    }
}