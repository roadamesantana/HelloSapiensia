using GerenciadorDeConfiguracao.Domain;
using System.Data.Entity.ModelConfiguration;

namespace GerenciadorDeConfiguracao.Data
{
    class FuncaoMap : EntityTypeConfiguration<Funcao>
    {
        public FuncaoMap()
        {
            ToTable("Funcao");

            HasKey(x => x.Id);

            HasRequired(x => x.Casa);
        }
    }
}
