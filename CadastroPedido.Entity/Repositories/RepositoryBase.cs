using CadastroPedido.Entity.Contexto;
using CadastroPedido.Entity.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CadastroPedido.Entity.Repositories
{
    public class RepositoryBase<T> : IDisposable, IRepositoryBase<T> where T: class
    {
        protected CadastroPedidosDataContext _ctx = null;

        public RepositoryBase(CadastroPedidosDataContext ctx)
        {
            _ctx = ctx;
        }

        public void Create(T entity)
        {
            _ctx.Set<T>().Add(entity);
            _ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            _ctx.Set<T>().Remove(entity);
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }

        public List<T> Get()
        {
            return _ctx.Set<T>().ToList<T>();
        }

        public T GetById(int id)
        {
            return _ctx.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _ctx.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
