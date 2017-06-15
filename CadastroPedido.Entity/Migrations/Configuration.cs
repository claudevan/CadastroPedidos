namespace CadastroPedido.Entity.Migrations
{
    using CadastroPedidos.Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Contexto.CadastroPedidosDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Contexto.CadastroPedidosDataContext context)
        {
            #region "Adiciona Clientes"
            IList<Cliente> clientes = new List<Cliente>();

            clientes.Add(new Cliente() { CPF = "123456789", Nome = "Cliente Padrão" });
            clientes.Add(new Cliente() { CPF = "987654321", Nome = "Ubisoft" });
            clientes.Add(new Cliente() { CPF = "123789654", Nome = "Valve" });
            clientes.Add(new Cliente() { CPF = "654789321", Nome = "Steam" });

            foreach (var cliente in clientes)
            {
                context.Clientes.AddOrUpdate(cliente);
            }
            #endregion

            #region "Adiciona Produtos"
            IList<Produto> produtos = new List<Produto>();

            produtos.Add(new Produto() { Descricao = "CS GO", Valor = 25.50M });
            produtos.Add(new Produto() { Descricao = "R6 Siege", Valor = 100.00M });
            produtos.Add(new Produto() { Descricao = "FIFA 2017", Valor = 100.75M });
            produtos.Add(new Produto() { Descricao = "Destiny 2", Valor = 250.50M });
            produtos.Add(new Produto() { Descricao = "Overwatch", Valor = 90.89M });
            produtos.Add(new Produto() { Descricao = "GOD OF WAR", Valor = 50.74M });

            foreach (var produto in produtos)
            {
                context.Produtos.AddOrUpdate(produto);
            }
            #endregion

            base.Seed(context);
        }
    }
}
