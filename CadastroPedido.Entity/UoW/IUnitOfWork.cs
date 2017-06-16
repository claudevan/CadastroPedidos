using System;

namespace CadastroPedido.Entity.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
