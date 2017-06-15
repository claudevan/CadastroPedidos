using CadastroPedidos.Models;
using System.Data.Entity.ModelConfiguration;

namespace CadastroPedido.Entity.Config
{
    public class ProdutoConfig : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfig()
        {
            ToTable("Produtos");

            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(x => x.Descricao)
                .IsRequired();

            Property(x => x.Valor)
                .IsRequired();

        }
    }
}
