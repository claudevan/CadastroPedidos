using CadastroPedido.Entity.Contexto;
using CadastroPedido.Entity.Contracts;
using CadastroPedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CadastroPedido.Entity.Repositories
{
    public class RepositoryPedido : RepositoryBase<Pedido>, IRepositoryPedido
    {
        public RepositoryPedido(CadastroPedidosDataContext ctx) : base(ctx)
        {
        }

        public List<Pedido> Pesquisa(int cliente, int numeroPedido, DateTime dataInicial, DateTime dataFinal)
        {
            var query = _ctx.Pedidos;

            if (cliente > 0) query.Where(w => w.ClienteId == cliente);
            if (numeroPedido > 0) query.Where(w => w.Numero == numeroPedido);
            if (dataInicial > DateTime.MinValue) query.Where(w => w.DataCadastro >= dataInicial);
            if (dataFinal > DateTime.MinValue) query.Where(w => w.DataCadastro <= dataFinal);
            
            return query.ToList();
        }
    }
}
