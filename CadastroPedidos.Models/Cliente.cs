using System.Collections.Generic;

namespace CadastroPedidos.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
