using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadastroPedidos.Controllers
{
    public class PedidoController : Controller
    {
        // GET: Pedido
        public ActionResult Index()
        {
            
            List<SelectListItem> clientes = new List<SelectListItem>();
            clientes.Add(new SelectListItem() { Text = "Cliente 1", Value = "1" });
            clientes.Add(new SelectListItem() { Text = "Cliente 2", Value = "2" });
            clientes.Add(new SelectListItem() { Text = "Cliente 3", Value = "3" });
            clientes.Add(new SelectListItem() { Text = "Cliente 4", Value = "4" });

            ViewBag.Clientes = clientes;

            return View();
        }
    }
}