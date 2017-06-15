using CadastroPedidos.Models;
using System;
using System.Collections.Generic;

namespace CadastroPedido.Entity.Contracts
{
    public interface IRepositoryPedido : IRepositoryBase<Pedido>
    {
        List<Pedido> Pesquisa(int cliente, int numeroPedido, DateTime dataInicial, DateTime dataFinal);
    }
}
