using Business.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AplicationContext _context;

        public Repository(AplicationContext context)
        {
            _context = context;
        }

        public async Task Create(T entityCreate)
        {
            _context.Set<T>().Add(entityCreate);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T delete)
        {
            _context.Set<T>().Remove(delete);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task Update(T update)
        {
            _context.Set<T>().Update(update);
            await _context.SaveChangesAsync();
        }
    }
}
