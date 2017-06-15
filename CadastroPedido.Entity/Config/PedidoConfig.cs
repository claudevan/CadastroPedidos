using CadastroPedidos.Models;
using System.Data.Entity.ModelConfiguration;

namespace CadastroPedido.Entity.Config
{
    public class PedidoConfig : EntityTypeConfiguration<Pedido>
    {
        public PedidoConfig()
        {
            ToTable("Pedidos");

            HasKey(x => x.Id);

            Property(x => x.Numero)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(x => x.Valor)
                .HasPrecision(3, 2)
                .IsRequired();

            Property(x => x.DataCadastro)
                .IsRequired();

            Property(x => x.DataAlteracao)
                .IsOptional();

            HasMany(x => x.Itens);

            HasRequired(x => x.Cliente)
                .WithRequiredPrincipal();
            
        }
    }
}
