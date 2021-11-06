using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task Create(T entityCreate);
        Task Update(T update);
        Task Delete(T delete);
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
    }
}
