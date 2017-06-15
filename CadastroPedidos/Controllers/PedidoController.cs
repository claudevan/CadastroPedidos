using CadastroPedido.Entity.Contracts;
using CadastroPedido.Entity.Repositories;
using CadastroPedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadastroPedidos.Controllers
{
    public class PedidoController : Controller
    {
        private IRepositoryPedido _db;
        private IRepositoryBase<Cliente> _dbCliente;

        public PedidoController(IRepositoryPedido db, IRepositoryBase<Cliente> dbCliente)
        {
            _db = db;
            _dbCliente = dbCliente;
        }

        // GET: Pedido
        public ActionResult Index()
        {
            var clientes = _dbCliente.Get().Select(s => new SelectListItem() { Text = s.Nome, Value = s.Id.ToString() }).ToList();
            
            ViewBag.Clientes = clientes;

            return View();
        }

        public ViewResult Pesquisa(int cliente, int numeroPedido, DateTime dataInicial, DateTime dataFinal)
        {
            var resultado = _db.Pesquisa(cliente, numeroPedido, dataInicial, dataFinal);

            return View("_Pesquisa", resultado);
        }
    }
}