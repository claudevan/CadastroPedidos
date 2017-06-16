using CadastroPedido.Entity.Contexto;

namespace CadastroPedido.Entity.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CadastroPedidosDataContext _ctx;

        public UnitOfWork(CadastroPedidosDataContext ctx)
        {
            _ctx = ctx;
        }

        public void Commit()
        {
            _ctx.SaveChanges();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}
