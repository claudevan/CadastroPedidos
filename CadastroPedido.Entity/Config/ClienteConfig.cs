using CadastroPedidos.Models;
using System.Data.Entity.ModelConfiguration;

namespace CadastroPedido.Entity.Config
{
    public class ClienteConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfig()
        {
            ToTable("Clientes");

            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(x => x.CPF)
                .HasMaxLength(9)
                .IsFixedLength()
                .IsRequired();

            Property(x => x.Nome)
                .IsRequired();

            //HasMany(x => x.Pedidos);
    }
    }
}
