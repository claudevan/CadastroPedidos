using System;

namespace CadastroPedidos.Models
{
    public class Item
    {
        public int Id { get; set; }
        public decimal Quantidade { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorTotal { get; set; }

        public virtual Pedido Pedido { get; set; }
        public virtual Produto Produto { get; set; }

        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
