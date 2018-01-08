using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.IRepository
{
    public interface IRepositoryBase<T> where T : class
    {
        // Gets all entities of type T
        IEnumerable<T> GetAll();
        // Get an entity by int id
        T GetByID(int id);
        // Get an entity using delegate
        T Get(Expression<Func<T, bool>> where);
        // Gets entities using delegate
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        // Marks an entity as modified
        bool Update(T item);
        // Marks an entity to be removed
        bool Delete(int id);
        // Marks an entity as new
        bool Create(T item);
        // Search entities by string name
        IEnumerable<T> SearchByName(string name);
    }
}
