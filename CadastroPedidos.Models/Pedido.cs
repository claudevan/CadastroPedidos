using System;
using System.Collections.Generic;

namespace CadastroPedidos.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public int ClienteId { get; set; }

        public virtual ICollection<Item> Itens { get; set; }
        public virtual Cliente Cliente { get; set; }

        public DateTime DataEntrega { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
