using System.Collections.Generic;

namespace Challenge2.Interfaces
{
    public interface IRepositories<T>
    {
        List<T> Lista();
        T ReturnById(int id);        
        void Enter(T entity);        
        void Delete(int id);        
        void Upadate(int id, T entity);
        int NextId();
    }
}