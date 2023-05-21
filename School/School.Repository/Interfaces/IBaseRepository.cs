using School.Infra.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infra.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task<int> Insert(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(int id);

        Task<int> UpdateStatus(bool active, params int[] id);

    }
}
