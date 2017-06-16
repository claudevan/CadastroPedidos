using CadastroPedidos.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CadastroPedidos.ViewModels
{
    public class PedidoVM
    {
        public PedidoVM()
        {
            Itens = new List<Item>();
        }

        public int Id { get; set; }
        [DisplayName("Número")]
        public int Numero { get; set; }
        [DisplayName("Cliente")]
        [Required(ErrorMessage = "Obrigatório informar um Cliente")]
        public int Cliente { get; set; }
        [DisplayName("Data Entrega")]
        [Required(ErrorMessage = "Obrigatório")]
        [DataType(DataType.Date)]
        public DateTime DataEntrega { get; set; }

        [DisplayName("Valor Total")]
        public decimal ValorTotal
        {
            get
            {
                return Itens.Sum(s => s.Valor);
            }
        }
        
        public virtual List<Item> Itens { get; set; }
    }
}