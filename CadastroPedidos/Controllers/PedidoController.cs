using CadastroPedido.Entity.Contracts;
using CadastroPedido.Entity.UoW;
using CadastroPedidos.Models;
using CadastroPedidos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CadastroPedidos.Controllers
{
    public class PedidoController : Controller
    {
        private IRepositoryPedido _ctx;
        private IRepositoryBase<Cliente> _ctxCliente;
        private IRepositoryBase<Produto> _ctxProduto;
        private IUnitOfWork _UoW;

        public PedidoController(IRepositoryPedido db, IRepositoryBase<Cliente> dbCliente, IUnitOfWork UoW, IRepositoryBase<Produto> ctxProduto)
        {
            _ctx = db;
            _ctxCliente = dbCliente;
            _UoW = UoW;
            _ctxProduto = ctxProduto;
        }

        // GET: Pedido
        public ActionResult Index()
        {
            ViewBag.Clientes = GetClientes();

            return View();
        }

        public ViewResult Pesquisa(int cliente, int numeroPedido, DateTime dataInicial, DateTime dataFinal)
        {
            var resultado = _ctx.Pesquisa(cliente, numeroPedido, dataInicial, dataFinal);

            return View("_Pesquisa", resultado);
        }

        public ViewResult Novo()
        {
            ViewBag.Clientes = GetClientes();
            ViewBag.Produtos = GetProdutos();

            return View();
        }

        public JsonResult Salvar(PedidoVM pedido)
        {
            Pedido model = new Pedido();

            Map(pedido, model);

            _ctx.Create(model);
            _UoW.Commit();

            return Json("{ resultado = true}", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetItem(int IdProduto)
        {
            Produto produto = _ctxProduto.GetById(IdProduto);

            Item item = new Item();
            item.Produto = produto;

            return Json(item, JsonRequestBehavior.AllowGet);
        }

        private List<SelectListItem> GetClientes()
        {
            return _ctxCliente.Get().Select(s => new SelectListItem() { Text = s.Nome, Value = s.Id.ToString() }).ToList();
        }

        private List<SelectListItem> GetProdutos()
        {
            return _ctxProduto.Get().Select(s => new SelectListItem() { Text = s.Descricao, Value = s.Id.ToString() }).ToList();
        }

        private void Map(PedidoVM vm, Pedido model)
        {
            model.ClienteId = vm.Cliente;
            model.DataEntrega = vm.DataEntrega;
            model.Itens = vm.Itens;
        }
    }
}