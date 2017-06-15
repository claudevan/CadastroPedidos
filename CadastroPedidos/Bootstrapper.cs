using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using CadastroPedido.Entity.Contracts;
using CadastroPedido.Entity.Repositories;
using CadastroPedido.Entity.Contexto;

namespace CadastroPedidos
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<CadastroPedidosDataContext, CadastroPedidosDataContext>();
            container.RegisterType<IRepositoryPedido, RepositoryPedido>();
            container.RegisterType(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            return container;
        }
    }
}