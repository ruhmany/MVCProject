using DomainLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos
{
    public class IClubRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly AppDbContext _appDbContext;
        public IClubRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<T> Add(T entity)
        {
            return await _appDbContext.Set<T>().AddAsync(entity) as T;
        }

        public T Delete(T entity)
        {
            return _appDbContext.Set<T>().Remove(entity) as T;
        }

        public async Task<T> GetAsync(int id)
        {
            return await _appDbContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _appDbContext.Set<T>().ToListAsync();
        }

        //public T Get(int id)
        //{
        //    return _appDbContext.Set<T>().Find(id);
        //}

        //public IEnumerable<T> GetAll()
        //{
        //    return _appDbContext.Set<T>().ToList();
        //}

        public T Update(T entity)
        {
            return _appDbContext.Set<T>().Update(entity) as T; 
        }

    }
}
