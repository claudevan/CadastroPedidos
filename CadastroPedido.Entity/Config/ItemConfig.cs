using CadastroPedidos.Models;
using System.Data.Entity.ModelConfiguration;

namespace CadastroPedido.Entity.Config
{
    public class ItemConfig : EntityTypeConfiguration<Item>
    {
        public ItemConfig()
        {
            ToTable("Itens");

            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(x => x.Quantidade)
                .HasPrecision(3, 2)
                .IsRequired();

            Property(x => x.Valor)
                .IsRequired();

            Property(x => x.PedidoId)
                .IsRequired();

            Property(x => x.ProdutoId)
                .IsRequired();

            Property(x => x.DataCadastro)
                .IsRequired();

            Property(x => x.DataAlteracao)
                .IsOptional();

            //HasRequired(x => x.Pedido)
            //    .WithRequiredPrincipal();

            //HasRequired(x => x.Produto)
            //    .WithRequiredPrincipal();
        }
        
    }
}
