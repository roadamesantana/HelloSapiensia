using GerenciadorDeConfiguracao.Domain;
using System.Data.Entity.ModelConfiguration;

namespace GerenciadorDeConfiguracao.Data
{
    public class CasaMap : EntityTypeConfiguration<Casa>
    {
        public CasaMap()
        {
            ToTable("Casa");

            HasKey(x => x.Id);

            Property(x => x.Nome).HasMaxLength(50).IsRequired();
        }
    }
}
