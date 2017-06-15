using System;
using System.Collections.Generic;

namespace CadastroPedido.Entity.Contracts
{
    public interface IRepositoryBase<T> where T : class
    {
        T GetById(int id);
        List<T> Get();
        void Update(T entity);
        void Create(T entity);
        void Delete(int id);
    }
}
